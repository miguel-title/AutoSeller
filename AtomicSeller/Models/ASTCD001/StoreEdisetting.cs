using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class StoreEdisetting
    {
        public int StoreSettingId { get; set; }
        public int? StoreId { get; set; }
        public string MerchantKey { get; set; }
        public string ObjectName { get; set; }
        public string FieldName { get; set; }
        public int? MaxSize { get; set; }
        public string RegularExpression { get; set; }
        public string Mandatory { get; set; }
        public string CheckValidEmail { get; set; }
        public string CheckValidDecimal { get; set; }
        public string CheckValidInt { get; set; }
        public string CheckValidDate { get; set; }
        public string DefaultValue { get; set; }
        public string ConditionFieldName { get; set; }
        public string ConditionFieldExpression { get; set; }
    }
}
