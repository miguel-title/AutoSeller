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
    public class LabelsViewModel
    {
        public List<LabelsDashboardViewModel> Dashboard { get; set; }

        public List<Delivery> Shipments { get; set; }
    }

    public enum LabelProcess
    { 
        Generate, 
        Preview, 
        Print, 
        MarkAsShipped 
    };

    public partial class LabelsDashboardViewModel
    {
        public DateTime CreateDate { get; set; }
        public int Product_ID { get; set; }
        public int Carrier_ID { get; set; }
        public string CarrierName { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> N { get; set; }
        public Nullable<int> T { get; set; }
        public Nullable<int> E { get; set; }
        public Nullable<int> P { get; set; }
        public Nullable<int> S { get; set; }
        public Nullable<int> C { get; set; }
        public Nullable<int> W { get; set; }
        public Nullable<int> CountShipmentID { get; set; }
    }

    public class MarkShippedConfirmVM
    {
        public int ShippingServiceID { get; set; }

        public DateTime CreateDate { get; set; }
        public List<DEALVM> DEALs { get; set; }

    }

}