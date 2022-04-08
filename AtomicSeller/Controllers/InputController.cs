using AtomicSeller.Models.ASTCD001;
using Microsoft.AspNetCore.Mvc;
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
    public class InputController : Controller
    {
        private IConfiguration Configuration;

        public InputController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        //SqlConnection con = new SqlConnection("Server=DESKTOP-8ICUFA8;Database=ASTCD001;Trusted_Connection=true;MultipleActiveResultSets=true;");

        public IActionResult InputIndex()
        {
            using (ASTCD001Context _context = new ASTCD001Context())
            {
                List<StockInput> StockInputs = _context.StockInputs.ToList();
                
                ViewBag.StockInputs = StockInputs;
            }

            return View();
        }

        public IActionResult InputProducts(int id)
        {
            using (ASTCD001Context _context = new ASTCD001Context())
            {
                List<StockInputProduct> StockInputProducts = _context.StockInputProducts.Where(sip=> sip.StockiInputId == id).ToList();
                ViewBag.StockInputProducts = StockInputProducts;
            }

            return View();
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
