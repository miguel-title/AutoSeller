using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class StoreCsopistatus
    {
        public int CsopistatusId { get; set; }
        public string CsopistatusKey { get; set; }
        public string CsopistatusToken { get; set; }
        public int? CsopistoreId { get; set; }
        public string CsopistatusExternalName { get; set; }
    }
}
