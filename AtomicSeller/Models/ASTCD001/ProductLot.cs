using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class ProductLot
    {
        public int ProductLotId { get; set; }
        public string ProductLotIdExt { get; set; }
        public string ProductLotKey { get; set; }
        public int ProductId { get; set; }
        public DateTime? BestBeforeDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? StockEntryDate { get; set; }
        public int? ProductQuantity { get; set; }
    }
}
