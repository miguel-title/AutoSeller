using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class AtomicSetting
    {
        public string KeyColumn { get; set; }
        public string Value { get; set; }
        public int? Id { get; set; }
        public int SettingId { get; set; }
    }
}
