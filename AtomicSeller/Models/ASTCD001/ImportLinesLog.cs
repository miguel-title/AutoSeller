using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class ImportLinesLog
    {
        public int ImportLineId { get; set; }
        public string ImportLine { get; set; }
        public DateTime? CreateDate { get; set; }
        public string User { get; set; }
        public string ImportFileName { get; set; }
    }
}
