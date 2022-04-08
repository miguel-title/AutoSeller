using AtomicSeller.Models.ASTCD001;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AtomicSeller.Controllers
{
    public class OrderController : Controller
    {
        private IConfiguration Configuration;

        public OrderController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AtomicJobsEntities"].ConnectionString);
        //SqlConnection con = new SqlConnection("Server=DESKTOP-8ICUFA8;Database=ASTCD001;Trusted_Connection=true;MultipleActiveResultSets=true;");

        public IActionResult OrderIndex()
        {
            //DataSet ds = GetData("SELECT  [OrderId],[OrderKey],[Order_Status] as [OrderStatus],CreateDate,CONCAT([DeliveryCompanyName],'/ ',[DeliveryFirstName] ,' ',[DeliveryLastName]) as PaymentInfo FROM [dbo].[Order]");
            //List<Order> orders = ConvertDataTable<Order>(ds.Tables[0]);

            using (ASTCD001Context _context = new ASTCD001Context())
            {
                var _Orders = (from Order in _context.Orders select Order);
                _Orders = _Orders.Where(o => o.CreateDate != null);
                //_Orders = _Orders.Take(1000);
                List<Order> orders = new List<Order>();

                try
                {
                    orders = _Orders.ToList();
                } catch(Exception ex) 
                {
                
                }

                List<OrderVM> OrderVMs = new List<OrderVM>();
                foreach (Order _Order in orders)
                {
                    OrderVM _OrderVM = new OrderVM();
                    _OrderVM.Order = _Order;
                    _OrderVM.ExtendedName = _Order.DeliveryCompanyName + "/ " + _Order.DeliveryFirstName + " " + _Order.DeliveryLastName;
                    OrderVMs.Add(_OrderVM);
                }
                ViewBag.OrderVMs = OrderVMs;
            }

            return View();
        }

        public IActionResult OrderEdit(int id)
        {
            DEALVM _DealVM = new DEALVM();
            OrderVM _OrderVM = new OrderVM();
            _DealVM.OrderVMs = new List<OrderVM>();
            _DealVM.OrderVMs.Add(_OrderVM);
            List<Order> orders;
            //List<Delivery> _Deliveries;

            using (ASTCD001Context _context = new ASTCD001Context())
            {
                orders = (from Order in _context.Orders
                          join Customer in _context.Customers on Order.OrderCustomerId equals Customer.CustomerId
                          where Order.OrderId == id
                          select Order).ToList();

                _OrderVM.Order = orders.First();

                int OrderID = _OrderVM.Order.OrderId;
                int CustomerID = (int)_OrderVM.Order.OrderCustomerId;

                _DealVM.Customer = _context.Customers.FirstOrDefault(op => op.CustomerId == CustomerID);

                _DealVM.OrderVMs.First().OrderProducts = _context.OrderProducts.Where(op => op.OrderId == OrderID).ToList();

                List<OrderDelivery> OrderDeliveries = _context.OrderDeliveries.Where(op => op.OrderId == OrderID).ToList();

                _DealVM.OrderDeliveries = OrderDeliveries;
                _DealVM.DeliveryVMs = new List<DeliveryVM>();

                // Fill up first products
                var FirstDeliveryID = OrderDeliveries.First().DeliveryId;
                Delivery _FirstDelivery = _context.Deliveries.FirstOrDefault(dp => dp.DeliveryId == FirstDeliveryID);
                List<DeliveryProduct> _DeliveryProducts1st = _context.DeliveryProducts.Where(dp => dp.DeliveryId == _FirstDelivery.DeliveryId).ToList();

                if (_DeliveryProducts1st == null || _DeliveryProducts1st.Count == 0)
                {
                    foreach (var _OrderProduct in _DealVM.OrderVMs.First().OrderProducts)
                    {
                        DeliveryProduct _DeliveryProduct = new();
                        _DeliveryProduct.DeliveryId = FirstDeliveryID;
                        _DeliveryProduct.Sku = _OrderProduct.Sku;
                        _DeliveryProduct.ProductName = _OrderProduct.ProductName;
                        _DeliveryProduct.Quantity = _OrderProduct.Quantity;
                        _DeliveryProduct.PriceExclTax = _OrderProduct.PriceExclTax;
                        _DeliveryProduct.Price = _OrderProduct.Price;

                        _context.DeliveryProducts.Add(_DeliveryProduct);
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (string.IsNullOrEmpty(_DealVM.Customer.FirstName))
                    _DealVM.Customer.FirstName = _OrderVM.Order.DeliveryFirstName;
                if (string.IsNullOrEmpty(_DealVM.Customer.LastName))
                    _DealVM.Customer.FirstName = _OrderVM.Order.DeliveryLastName;


                foreach (var _OrderDelivery in OrderDeliveries)
                {
                    Delivery _Delivery = _context.Deliveries.FirstOrDefault(dp => dp.DeliveryId == _OrderDelivery.DeliveryId);

                    List<DeliveryProduct> _DeliveryProducts = _context.DeliveryProducts.Where(dp => dp.DeliveryId == _OrderDelivery.DeliveryId).ToList();

                    List<DeliveryProductVM> _DeliveryProductsVM = new List<DeliveryProductVM>();

                    foreach (var elt in _DeliveryProducts)
                    {
                        DeliveryProductVM _DeliveryProductVM = new DeliveryProductVM();

                        _DeliveryProductVM.DeliveryProduct = elt;
                        _DeliveryProductVM.AvailableStock = new Random().Next(0, 250);
                        _DeliveryProductsVM.Add(_DeliveryProductVM);
                    }

                    List<DeliveryPackage> _DeliveryPackages = _context.DeliveryPackages.Where(dp => dp.DeliveryId == _OrderDelivery.DeliveryId).ToList();
                    DeliveryVM _DeliveryVM = new DeliveryVM();
                    _DeliveryVM.Delivery = _Delivery;
                    _DeliveryVM.DeliveryProductVMs = _DeliveryProductsVM;
                    _DeliveryVM.DeliveryPackages = _DeliveryPackages;
                    _DealVM.DeliveryVMs.Add(_DeliveryVM);
                }

                _DealVM.CustomerPool = new List<CustomerVM>();
                List<Customer> _Customers = _context.Customers.ToList();
                List<CustomerVM> _CustomerVMs = new List<CustomerVM>();

                foreach (var elt in _Customers)
                {
                    CustomerVM _CustomerVM = new CustomerVM();

                    _CustomerVM.Customer = elt;
                    _CustomerVM.Fullname = elt.FirstName + " " + elt.LastName + " " + elt.Company;
                    _CustomerVMs.Add(_CustomerVM);
                }
                _DealVM.CustomerPool = _CustomerVMs;

                _DealVM.ProductsPool = new List<ProductVM>();
                List<Product> _Products = new List<Product>();
                try
                {
                    _Products = _context.Products.Where(p => p.MerchantKey == "MASPATULE").ToList();
                }
                catch (Exception ex)
                {

                }
                List<ProductVM> _ProductVMs = new List<ProductVM>();
                foreach (var elt in _Products)
                {
                    ProductVM _ProductVM = new ProductVM();
                    _ProductVM.Product = elt;
                    _ProductVMs.Add(_ProductVM);
                }
                _DealVM.ProductsPool = _ProductVMs;

                ViewBag.DEALVM = _DealVM;
            }

            return View(_DealVM);
        }

        [HttpPost]
        public IActionResult Save(DEALVM objDealVM, OrderVM objOrder, DeliveryVM objDeliveryVM)
        {

            bool isOrderSave = true;
            bool isCustomerSave = true;
            bool isDeliverySave = true;
            //string orderupdatequery = "update [Order] set CreateDate='" + objOrder.Order.CreateDate + "',Purchase_date='" + objOrder.Order.PurchaseDate +
            //    "',Payment_Date='" + objOrder.Order.PaymentDate + "',TransactionPrice='" + objOrder.Order.TransactionPrice +
            //    "',OrderKey='" + objOrder.Order.OrderKey + "' where OrderID = " + objOrder.Order.OrderId.ToString();

            //if (!NonExecuteQuery(orderupdatequery))
            //{
            //    isOrderSave = false;
            //}

            //string customerupdatequery = "update [Customer] set LastName = '" + objDealVM.Customer.LastName  + "', company = '" + objDealVM.Customer.Company + 
            //    "', Address0 = '" + objDealVM.Customer.Address0 + "', Address1 = '" + objDealVM.Customer.Address1 + "', Address2 = '" + objDealVM.Customer.Address2 + 
            //    "', ZipCode = '" + objDealVM.Customer.ZipCode + "', City = '" + objDealVM.Customer.City + "', StateProvince = '" + objDealVM.Customer.StateProvince + "', CountryName = '" 
            //    + objDealVM.Customer.CountryName + "', Phone1 = '" + objDealVM.Customer.Phone1 + "', MobilePhone = '" + objDealVM.Customer.MobilePhone + "', Email1 = '" +
            //    objDealVM.Customer.Email1  + "' where CustomerID = " + objDealVM.Customer.CustomerId.ToString();

            //if (!NonExecuteQuery(customerupdatequery))
            //{
            //    isCustomerSave = false;
            //}

            ////todo: objDeliveryVM.Delivery.ShippingService
            //string deliveryupdatequery = "update [Delivery] set SenderName = '" + objDeliveryVM.Delivery.SenderName + "', SenderCompanyName = '" + objDeliveryVM.Delivery.SenderCompanyName +
            //    "', SenderAddr0 = '" + objDeliveryVM.Delivery.SenderAddr0 + "', SenderAddr1 = '" + objDeliveryVM.Delivery.SenderAddr1 + "', SenderAddr2 = '" + objDeliveryVM.Delivery.SenderAddr2 +
            //    "', SenderZip = '" + objDeliveryVM.Delivery.SenderZip + "', SenderCity = '" + objDeliveryVM.Delivery.SenderCity + "', SenderStateProvinceCode = '" + objDeliveryVM.Delivery.SenderStateProvinceCode + "', SenderCountryLib = '"
            //    + objDeliveryVM.Delivery.SenderCountryLib + "', SenderPhoneNumber = '" + objDeliveryVM.Delivery.SenderPhoneNumber + "', SenderEmail = '" +
            //    objDeliveryVM.Delivery.SenderEmail + "', SenderRelayNumber = '" + objDeliveryVM.Delivery.SenderRelayNumber + "', ShippingService = " + 0 +
            //    ", ShippingCostPrice = " + objDeliveryVM.Delivery.ShippingCostPrice.ToString() + ", CarrierServiceKey = '" + objDeliveryVM.Delivery.CarrierServiceKey + 
            //    "', Signed = '" + objDeliveryVM.Delivery.Signed + "', ShippingDate = '" + objDeliveryVM.Delivery.ShippingDate + 
            //    "', DeliveryDate = '" + objDeliveryVM.Delivery.DeliveryDate + "', DeliveryInstructions1 = '" + objDeliveryVM.Delivery.DeliveryInstructions1 + "' where DeliveryID = " + objDeliveryVM.Delivery.DeliveryId.ToString();

            //if (!NonExecuteQuery(deliveryupdatequery))
            //{
            //    isDeliverySave = false;
            //}

            using (ASTCD001Context _context = new ASTCD001Context())
            {
                Order orderToUpdate = _context.Orders.FirstOrDefault(o => o.OrderId == objOrder.Order.OrderId);
                orderToUpdate.CreateDate = objOrder.Order.CreateDate;
                orderToUpdate.PurchaseDate = objOrder.Order.PurchaseDate;
                orderToUpdate.PaymentDate = objOrder.Order.PaymentDate;
                orderToUpdate.OrderKey = objOrder.Order.OrderKey;
                orderToUpdate.TransactionPrice = objOrder.Order.TransactionPrice;

                Customer customerToUpdate = _context.Customers.FirstOrDefault(o => o.CustomerId == objDealVM.Customer.CustomerId);
                customerToUpdate.LastName = objDealVM.Customer.LastName;
                customerToUpdate.Company = objDealVM.Customer.Company;
                customerToUpdate.Address0 = objDealVM.Customer.Address0;
                customerToUpdate.Address1 = objDealVM.Customer.Address1;
                customerToUpdate.Address2 = objDealVM.Customer.Address2;
                customerToUpdate.ZipCode = objDealVM.Customer.ZipCode;
                customerToUpdate.City = objDealVM.Customer.City;
                customerToUpdate.StateProvince = objDealVM.Customer.StateProvince;
                customerToUpdate.CountryName = objDealVM.Customer.CountryName;
                customerToUpdate.Phone1 = objDealVM.Customer.Phone1;
                customerToUpdate.MobilePhone = objDealVM.Customer.MobilePhone;
                customerToUpdate.Email1 = objDealVM.Customer.Email1;

                Delivery senderToUpdate = _context.Deliveries.FirstOrDefault(o => o.DeliveryId == objDeliveryVM.Delivery.DeliveryId);
                senderToUpdate.SenderName = objDeliveryVM.Delivery.SenderName;
                senderToUpdate.SenderCompanyName = objDeliveryVM.Delivery.SenderCompanyName;
                senderToUpdate.SenderAddr0 = objDeliveryVM.Delivery.SenderAddr0;
                senderToUpdate.SenderAddr1 = objDeliveryVM.Delivery.SenderAddr1;
                senderToUpdate.SenderAddr2 = objDeliveryVM.Delivery.SenderAddr2;
                senderToUpdate.SenderZip = objDeliveryVM.Delivery.SenderZip;
                senderToUpdate.SenderCity = objDeliveryVM.Delivery.SenderCity;
                senderToUpdate.SenderStateProvinceCode = objDeliveryVM.Delivery.SenderStateProvinceCode;
                senderToUpdate.SenderCountryLib = objDeliveryVM.Delivery.SenderCountryLib;
                senderToUpdate.SenderPhoneNumber = objDeliveryVM.Delivery.SenderPhoneNumber;
                senderToUpdate.SenderEmail = objDeliveryVM.Delivery.SenderEmail;
                senderToUpdate.SenderRelayNumber = objDeliveryVM.Delivery.SenderRelayNumber;

                senderToUpdate.ShippingService = objDeliveryVM.Delivery.ShippingService;
                senderToUpdate.ShippingCostPrice = objDeliveryVM.Delivery.ShippingCostPrice;
                senderToUpdate.CarrierServiceKey = objDeliveryVM.Delivery.CarrierServiceKey;
                senderToUpdate.Signed = objDeliveryVM.Delivery.Signed;
                senderToUpdate.ShippingDate = objDeliveryVM.Delivery.ShippingDate;
                senderToUpdate.DeliveryDate = objDeliveryVM.Delivery.DeliveryDate;
                senderToUpdate.DeliveryInstructions1 = objDeliveryVM.Delivery.DeliveryInstructions1;

                
                try
                {
                    _context.SaveChanges();
                }
                catch (RetryLimitExceededException) // dex 
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                catch (Exception ex)
                {
                    isOrderSave = false;
                }

                try
                {
                    _context.SaveChanges();
                }
                catch (RetryLimitExceededException) // dex 
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                catch (Exception ex)
                {
                    isCustomerSave = false;
                }

                try
                {
                    _context.SaveChanges();

                }
                catch (RetryLimitExceededException) // dex 
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                catch (Exception ex)
                {
                    isDeliverySave = false;
                }

                //return View(orderToUpdate);
            }

            //return RedirectToAction("OrderEdit", new { id = objOrder.Order.OrderId });
            //return Redirect(Request.Headers["Referer"].ToString());
            //return View();

            if (isOrderSave && isCustomerSave && isDeliverySave)
            {
                return Json("saved successfully");
            }
            else
            {
                return Json("Something went wrong:\\nordersave:" + isOrderSave + "\\ncustomersave:" + isCustomerSave + "\\ndeliverysave:" + isDeliverySave);
            }

        }

        public class savedeliverydata
        {
            public int nDeliveryProductID { get; set; }
            public string strsku { get; set; }
            public string strmpn { get; set; }
            public string strgtin { get; set; }
            public string strbrand { get; set; }
            public string strproductname { get; set; }
            public string strquantity { get; set; }
            public string strstock { get; set; }
            public string stroutput { get; set; }
            public string strminus { get; set; }
            public string stroutofstock { get; set; }
            public int nDeliveryID { get; set; }
            public int nOrderID { get; set; }
        }

        public JsonResult SaveDeliveryProduct(List<savedeliverydata> savedeliverydatas)
        {

            foreach (savedeliverydata data in savedeliverydatas){
                using (ASTCD001Context _context = new ASTCD001Context())
                {

                    if (data.nDeliveryProductID != 0)
                    {
                        DeliveryProduct _DBproduct = _context.DeliveryProducts.FirstOrDefault(o => o.DeliveryProductId == data.nDeliveryProductID);
                        _DBproduct.Sku = data.strsku;
                        _DBproduct.Quantity= int.Parse(data.strquantity);
                        _DBproduct.OrderedQuantity = int.Parse(data.strquantity);
                        _DBproduct.ProductName = data.strproductname;

                        Product _product = _context.Products.FirstOrDefault(o => o.Sku == data.strsku);

                        try
                        {
                            _context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            string ErrorMessage = ex.Message;
                        }
                    }
                    else
                    {
                        DeliveryProduct addingproduct = new DeliveryProduct();
                        addingproduct.Sku = data.strsku;
                        addingproduct.Quantity = int.Parse(data.strquantity);
                        addingproduct.OrderedQuantity = int.Parse(data.strquantity);
                        addingproduct.ProductName = data.strproductname;
                        addingproduct.DeliveryId = data.nDeliveryID;

                        Product _product = _context.Products.FirstOrDefault(o => o.Sku == data.strsku);

                        _context.Add(addingproduct);
                        try
                        {
                            _context.SaveChanges();
                        }catch(Exception ex)
                        {
                            string strmsg = ex.Message;
                        }
                    }
                }
            }

            //foreach (savedeliverydata data in savedeliverydatas)
            //{
            //    int nDeliveryProductID = data.nDeliveryProductID;
            //    string query = "";
            //    if (nDeliveryProductID != 0)
            //    {
            //        query = " update DeliveryProduct set SKU = '" + data.strsku + "', Quantity =  '" + data.strquantity + "', ProductName = '" + data.strproductname + "' where DeliveryProductID=" + nDeliveryProductID.ToString();
            //    }
            //    else
            //    {
            //        query = " insert into DeliveryProduct(SKU, Quantity, DeliveryID, ProductName) values ('" + data.strsku + "','" + data.strquantity + "','" + data.nDeliveryID.ToString() + "','" + data.strproductname + "')";
            //    }
            //    if (NonExecuteQuery(query))
            //    {
            //    }
            //    else
            //    {
            //    }

            //}

            return Json("success");
        }

        public JsonResult DeleteDeliveryProduct(int ID) 
        {
            string query = " delete from DeliveryProduct where DeliveryProductID=" + ID.ToString();
            if (NonExecuteQuery(query))
            {
                return Json("delete successfully");
            }
            else
            {
                return Json("something went wrong");
            }
        }

        public JsonResult DeleteDelivery(int id)
        {
            string query = " delete from DeliveryProduct where [DeliveryID]=" + id.ToString();
            query += " delete from OrderDelivery where [DeliveryID]=" + id.ToString();
            query += " delete from Delivery where [DeliveryID]=" + id.ToString();
            if (NonExecuteQuery(query))
            {
                return Json("saved successfully");
            }
            else
            {
                return Json("something went wrong");
            }
        }

        public DataSet GetData(string query)
        {
            SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("ASTCD001Entities"));
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                return ds;
            }
            return ds;
        }

        public bool NonExecuteQuery(string query)
        {
            SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("ASTCD001Entities"));
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {

                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {

                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] == DBNull.Value)
                        {
                            if (pro.PropertyType.Name == "Int32" || pro.PropertyType.Name == "Decimal")
                                pro.SetValue(obj, 0, null);
                            else if (pro.PropertyType.Name == "String")
                                pro.SetValue(obj, "", null);
                        }
                        else
                            pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
