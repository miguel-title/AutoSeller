using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTLD
{
    public partial class DailyJob
    {
        public int CronId { get; set; }
        public TimeSpan? DailyTime { get; set; }
        public int? JobType { get; set; }
        public int? SettingId { get; set; }
        public int? ClientId { get; set; }
    }
}
