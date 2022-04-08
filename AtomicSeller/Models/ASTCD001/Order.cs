using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public string OrderKey { get; set; }
        public string OrderIdExt { get; set; }
        public string OrderStatus { get; set; }
        public string OrderStatusExt { get; set; }
        public string StoreKey { get; set; }
        public string MerchantKey { get; set; }
        public int? MerchantId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string StoreType { get; set; }
        public string StoreName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingAddressName { get; set; }
        public string AddressStreet1 { get; set; }
        public string AddressStreet2 { get; set; }
        public string AddressStreet3 { get; set; }
        public string PostalCode { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPhoneNumber { get; set; }
        public string BuyerSPhone { get; set; }
        public string BuyerSEmail { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ShipmentTrackingNumber { get; set; }
        public string ShippingPrice { get; set; }
        public string TransactionId { get; set; }
        public string EbayBuyerFirstName { get; set; }
        public string EbayBuyerUserLastName { get; set; }
        public string TransactionPrice { get; set; }
        public string ShippingCarrierUsed { get; set; }
        public string SalesRecordNumber { get; set; }
        public string FulfillmentChannel { get; set; }
        public string ShipServiceLevel { get; set; }
        public int? OrderShipmentId { get; set; }
        public string PaymentReferenceId { get; set; }
        public string OrderBuyerUserId { get; set; }
        public int? OrderCustomerId { get; set; }
        public string CheckoutMessage { get; set; }
        public DateTime CreationDate { get; set; }
        public string PaymentInfo { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Currency { get; set; }
        public string OrderType { get; set; }
        public string DeliveryStreetNumber { get; set; }
        public string DeliveryAddr0 { get; set; }
        public string DeliveryAddr1 { get; set; }
        public string DeliveryAddr2 { get; set; }
        public string DeliveryAddr3 { get; set; }
        public string DeliveryFirstName { get; set; }
        public string DeliveryLastName { get; set; }
        public string DeliveryCompanyName { get; set; }
        public string DeliveryZipCode { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryCountryIsocode { get; set; }
        public string DeliveryCountryName { get; set; }
        public string DeliveryEmail { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryMobile { get; set; }
        public string ShippingServiceKey { get; set; }
        public string ShippingServiceName { get; set; }
        public string DeliveryRelayNumber { get; set; }
        public string DeliveryRelayCountryCode { get; set; }
        public string CustomerLanguageCode { get; set; }
        public string InsurranceYn { get; set; }
        public string ParcelValueExclTax { get; set; }
        public string ParcelValueInclTax { get; set; }
        public string ParcelValueTax { get; set; }
        public string ParcelShippingAmountInclTax { get; set; }
        public string ParcelInsurranceValueInclTax { get; set; }
        public string CustomContent { get; set; }
        public DateTime? OrderToWmstimeStamp { get; set; }
        public string Wmskey { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
