using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Edierror
    {
        public int EdierrorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string StoreName { get; set; }
        public string Message { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string MerchantKey { get; set; }
        public string CustomerKey { get; set; }
        public string ShipmentKey { get; set; }
        public string OrderKey { get; set; }
        public string OrderProductKey { get; set; }
        public string InvoiceKey { get; set; }
        public string AlertSent { get; set; }
    }
}
