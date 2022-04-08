using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class ExportFile
    {
        public int ExportFileId { get; set; }
        public string Title { get; set; }
        public string PrimaryKeyDatabaseField { get; set; }
        public int? ExcelKeyColumn { get; set; }
    }
}
