using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTLD
{
    public partial class UserProfile
    {
        public int UserProfileId { get; set; }
        public string ProfileName { get; set; }
        public string Comment { get; set; }
    }
}
