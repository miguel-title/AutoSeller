using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AtomicOrderAPI.Models;
using AtomicSeller.Helpers;
using AtomicSeller.Models;

namespace AtomicSeller.ViewModels
{
    public class SalesViewModel
    {
        public List<SalesDashboardViewModel> Dashboard { get; set; }

        public List<Delivery> Shipments { get; set; }
    }

    public enum SaleProcess
    { 
        Generate, 
        Preview, 
        Print, 
        MarkAsShipped 
    };

    public partial class SalesDashboardViewModel
    {
        public DateTime CreateDate { get; set; }
        public int Store_ID { get; set; }
        public int Carrier_ID { get; set; }
        public string CarrierName { get; set; }
        public string StoreName { get; set; }
        public Nullable<int> N { get; set; }
        public Nullable<int> T { get; set; }
        public Nullable<int> E { get; set; }
        public Nullable<int> P { get; set; }
        public Nullable<int> D { get; set; }
        public Nullable<int> S { get; set; }
        public Nullable<int> C { get; set; }
        public Nullable<int> W { get; set; }
        public Nullable<int> CountOrderID { get; set; }
    }

    public class MarkSalesConfirmVM
    {
        public int StoreID { get; set; }
        public DateTime CreateDate { get; set; }
        public List<DEALVM> DEALs { get; set; }

    }

}