using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class StoreShippingSetting
    {
        public int StoreShippingSettingsId { get; set; }
        public int? StoreId { get; set; }
        public string StoreKey { get; set; }
        public string ShippingServiceKeywords { get; set; }
        public string CarrierServiceKey { get; set; }
        public string ProductCode { get; set; }
    }
}
