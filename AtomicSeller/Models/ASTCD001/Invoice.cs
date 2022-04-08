using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoicePath { get; set; }
        public string InvoiceNr { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? CustomerId { get; set; }
        public string TotalAmount { get; set; }
        public string TotalVat { get; set; }
        public string TotalExclVat { get; set; }
        public string TotalShipping { get; set; }
        public string Currency { get; set; }
        public string OrderKey { get; set; }
        public string PayTerms { get; set; }
        public string DelTerms { get; set; }
        public string DelTransportTerms { get; set; }
        public string OrderReference { get; set; }
        public string CustomerMarking { get; set; }
        public string Salesman { get; set; }
        public string InvoiceBase64 { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingCompany { get; set; }
        public string BillingAdr0 { get; set; }
        public string BillingAdr1 { get; set; }
        public string BillingAdr2 { get; set; }
        public string BillingZipCode { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingCountryCode { get; set; }
        public string BillingEmail { get; set; }
        public string BillingPhone { get; set; }
        public int? OrderId { get; set; }
    }
}
