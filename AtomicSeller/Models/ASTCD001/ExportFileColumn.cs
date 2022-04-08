using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class ExportFileColumn
    {
        public int ExportFileColumnId { get; set; }
        public int ExportFileId { get; set; }
        public string DataBaseField { get; set; }
        public string FileField { get; set; }
        public int? FieldOrder { get; set; }
    }
}
