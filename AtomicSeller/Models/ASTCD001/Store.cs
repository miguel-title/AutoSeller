using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Store
    {
        public int StoreId { get; set; }
        public string StoreIdExt { get; set; }
        public string StoreKey { get; set; }
        public string MerchantKey { get; set; }
        public int? MerchantId { get; set; }
        public bool? Active { get; set; }
        public int? StoreType { get; set; }
        public string StoreName { get; set; }
        public string ProviderId { get; set; }
        public string AppId { get; set; }
        public string StoreApiurl { get; set; }
        public int? NumberOfDays { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public string OauthVerifier { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ShopId { get; set; }
        public string EbayAuthToken { get; set; }
        public string AmazonMarketPlaceId { get; set; }
        public string AmazonSellerId { get; set; }
        public string AmazonAccessId { get; set; }
        public string AmazonSecretKey { get; set; }
        public string TypeLabel { get; set; }
        public string Country { get; set; }
        public string PriceMinisterLogin { get; set; }
        public string PriceMinisterToken { get; set; }
        public string WoocommerceKey { get; set; }
        public string WoocommerceSecret { get; set; }
        public string StoreEdiftpurl { get; set; }
        public string StoreEdiftpuser { get; set; }
        public string StoreEdiftppassword { get; set; }
        public string StoreEdiftpordersFile { get; set; }
        public string EdilogErrorsEmails { get; set; }
        public string StockManagementMode { get; set; }
        public string DefaultWarehouseId { get; set; }
        public string DefaultInvoiceUrl { get; set; }
        public string DefaultTrackingUrl { get; set; }
        public string WebmasterEmail { get; set; }
        public string Wmskey { get; set; }
        public string Eorinumber { get; set; }
        public int? TrackingOutputType { get; set; }
    }
}
