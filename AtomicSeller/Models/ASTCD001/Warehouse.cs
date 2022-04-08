using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Warehouse
    {
        public int WarehouseId { get; set; }
        public int? TenantId { get; set; }
        public string WarehouseKey { get; set; }
        public string WarehouseName { get; set; }
        public string IsDefault { get; set; }
        public string AdrLine0 { get; set; }
        public string AdrLine1 { get; set; }
        public string AdrLine2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
