using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class InvoiceTemplate
    {
        public int InvoiceTemplateId { get; set; }
        public string LogoPath { get; set; }
        public string DefaultPayTerms { get; set; }
        public string DefaultDelTerms { get; set; }
        public string DefaultDelTransportTerms { get; set; }
        public string SellerCompanyName { get; set; }
        public string SellerCompanyAdr1 { get; set; }
        public string SellerCompanyAdr2 { get; set; }
        public string SellerCompanyAdr3 { get; set; }
        public string SellerCompanyZip { get; set; }
        public string SellerCompanyCountry { get; set; }
        public string SellerCompanyCity { get; set; }
        public string SellerCompanyPhone { get; set; }
        public string SellerCompanyEmail { get; set; }
        public string SellerCompanyLegalInfo { get; set; }
        public string DefaultCurrency { get; set; }
        public string LastInvoiceNr { get; set; }
    }
}
