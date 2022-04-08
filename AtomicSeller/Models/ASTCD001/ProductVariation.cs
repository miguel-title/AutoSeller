using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class ProductVariation
    {
        public int ProductVariationId { get; set; }
        public int? ProductId { get; set; }
        public string VariationIdext { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Price { get; set; }
    }
}
