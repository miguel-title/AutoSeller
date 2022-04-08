using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int? OrderId { get; set; }
        public string ItemId { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public string Price { get; set; }
        public string Tax { get; set; }
        public string Weight { get; set; }
        public int? Cn23categoryId { get; set; }
        public string PriceExclTax { get; set; }
        public string Rate { get; set; }
        public string SubTotalPriceExclTax { get; set; }
        public string SubTotalTax { get; set; }
        public string Eancode { get; set; }
        public string Width { get; set; }
        public string Depth { get; set; }
        public string Length { get; set; }
        public string VariationId { get; set; }
        public string BundleId { get; set; }
        public DateTime? BestBeforeDate { get; set; }
        public string ProductLotKey { get; set; }
        public string Hscode { get; set; }

        public virtual Order Order { get; set; }
    }
}
