using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class DeliveryPackage
    {
        public int DeliveryPackageId { get; set; }
        public int? DeliveryId { get; set; }
        public int? Number { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string CustomerReference { get; set; }
        public string PackagingDescription { get; set; }
        public string LabelPath { get; set; }
        public string InsurredValue { get; set; }
    }
}
