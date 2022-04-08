using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicSeller.Models.ASTCD001;

namespace AtomicSeller
{
    public class DEALStatus
    {
        public string Token { get; set; }
        public string InternalStatus { get; set; }
        public string Active { get; set; }
        public string Label { get; set; }
        public string Lang { get; set; }
        public DEALStatus(string _Token, string _InternalStatus, string _Active, string _Label, string _Lang)
        {
            Token = _Token;
            InternalStatus = _InternalStatus;
            Active = _Active;
            Label = _Label;
            Lang = _Lang;
        }

    }

    public class DEALStatusVM
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public DEALStatusVM(string _Code, string _Label)
        {
            Code = _Code;
            Label = _Label;
        }

    }

    public class DEALCarrierVM
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public DEALCarrierVM(string _Code, string _Label)
        {
            Code = _Code;
            Label = _Label;
        }

    }

    public class ProductShippingCategoryVM
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public ProductShippingCategoryVM(string _Code, string _Label)
        {
            Code = _Code;
            Label = _Label;
        }

    }

    public class DEALVM
    {
        public Customer Customer { get; set; }
        public string CustomerFullName { get; set; }
        public List<OrderVM> OrderVMs { get; set; } 
        public List<DeliveryVM> DeliveryVMs { get; set; } 
        public List<OrderDelivery> OrderDeliveries { get; set; }
        /// optional View
        public List<CustomerVM> CustomerPool { get; set; }
        public List<ProductVM> ProductsPool { get; set; }
    }

    public class ProductVM
    {
        public Product Product { get; set; }
        public List<ProductLot> ProductLots { get; set; }

    }


    public class CustomerVM
    {
        public Customer Customer { get; set; }
        
        public string Fullname { get; set; }
        /*
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string PostalCode { get; set; }
        public string State_Province { get; set; }
        */
    }

    public class OrderVM
    {
        public Order Order { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public List<Invoice> Invoices { get; set; }
        public string ExtendedName {get; set; }
}

    public class DeliveryVM 
    {
        public Delivery Delivery { get; set; }
        public int ShippingCarrierType { get; set; }
        public List<DeliveryProductVM> DeliveryProductVMs { get; set; }
        public List<DeliveryPackage> DeliveryPackages { get; set; }
    }

    public class DeliveryProductVM 
    {
        public DeliveryProduct DeliveryProduct { get; set; }
        public int AvailableStock { get; set; }
        public int OutOfStockQty { get; set; }
    }


}