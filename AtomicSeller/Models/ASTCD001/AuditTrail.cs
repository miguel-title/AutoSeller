using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class AuditTrail
    {
        public int AuditTrailId { get; set; }
        public string ThirdParty { get; set; }
        public string Method { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
