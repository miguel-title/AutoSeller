using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class ImportHeader
    {
        public int ImportHeaderId { get; set; }
        public string StoreKey { get; set; }
        public int? StoreId { get; set; }
        public string HeaderInternalName { get; set; }
        public string HeaderExternalName { get; set; }
    }
}
