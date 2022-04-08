using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class CarrierProduct
    {
        public int ProductId { get; set; }
        public string CarrierServiceKey { get; set; }
        public int? CarrierId { get; set; }
        public string Type { get; set; }
        public string ProductName { get; set; }
        public int? LabelTemplateId { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsDefault { get; set; }
        public string MerchantKey { get; set; }
    }
}
