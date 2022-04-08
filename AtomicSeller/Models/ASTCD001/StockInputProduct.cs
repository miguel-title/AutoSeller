using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class StockInputProduct
    {
        public int StockInputProductId { get; set; }
        public int? StockiInputId { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public string Decription { get; set; }
        public int? StockValue { get; set; }
        public string CellCode { get; set; }
    }
}
