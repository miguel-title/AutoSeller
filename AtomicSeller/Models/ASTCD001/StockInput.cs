using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class StockInput
    {
        public int StockInputId { get; set; }
        public DateTime? CreateTimeStamp { get; set; }
        public DateTime? InputDate { get; set; }
        public string InputKey { get; set; }
        public string Status { get; set; }
    }
}
