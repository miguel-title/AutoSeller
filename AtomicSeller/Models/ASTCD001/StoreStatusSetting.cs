using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class StoreStatusSetting
    {
        public int StoreStatusId { get; set; }
        public int? StoreId { get; set; }
        public string RuleKey { get; set; }
        public string ExternalStatusRule { get; set; }
        public string InternalStatusValue { get; set; }
    }
}
