using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Wm
    {
        public int Wmsid { get; set; }
        public string Wmskey { get; set; }
        public string Wmsname { get; set; }
        public int? Wmstype { get; set; }
        public string FtpserverUrl { get; set; }
        public string Ftpuser { get; set; }
        public string Ftppassword { get; set; }
        public string WareHouseIdExt { get; set; }
        public string FtpDefaultDir { get; set; }
    }
}
