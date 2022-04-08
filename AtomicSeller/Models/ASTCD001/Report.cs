using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public string ReportKey { get; set; }
        public string ReportName { get; set; }
        public string DataScopeFields { get; set; }
        public string DataScopeLimits { get; set; }
        public string OutputEmails { get; set; }
        public string OutputGoogleSheets { get; set; }
        public string OutputRdlc { get; set; }
        public string OutputFile { get; set; }
        public string OutputType { get; set; }
        public string OutputCredentials { get; set; }
    }
}
