using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Merchant
    {
        public int MerchantId { get; set; }
        public string MerchantKey { get; set; }
        public string MerchantName { get; set; }
        public string Comment { get; set; }
        public int? ProductsManagementOption { get; set; }
    }
}
