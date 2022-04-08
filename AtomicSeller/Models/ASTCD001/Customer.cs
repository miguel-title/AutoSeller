using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email1 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email2 { get; set; }
        public string CustomerBuyerUserId { get; set; }
        public string BuyerMainMkPlc { get; set; }
        public string MerchantKey { get; set; }
        public string Address0 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryName { get; set; }
        public string CountryIsocode { get; set; }
        public string MobilePhone { get; set; }
        public string Active { get; set; }
        public string Vip { get; set; }
    }
}
