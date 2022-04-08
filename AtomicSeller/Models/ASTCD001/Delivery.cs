using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Delivery
    {
        public Delivery()
        {
            DeliveryProducts = new HashSet<DeliveryProduct>();
        }

        public int DeliveryId { get; set; }
        public int? ShippingService { get; set; }
        public int? ShippingServiceId { get; set; }
        public string CarrierServiceKey { get; set; }
        public string MerchantKey { get; set; }
        public int? MerchantId { get; set; }
        public string ShippingMethodId { get; set; }
        public string ShippingMethodTitle { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string TrackingNumber { get; set; }
        public string ShipmentStatus { get; set; }
        public string ParcelWeight { get; set; }
        public string Signed { get; set; }
        public string Return { get; set; }
        public string ParcelValue { get; set; }
        public string ParcelInsuranceValue { get; set; }
        public string LabelPath { get; set; }
        public DateTime DepositDate { get; set; }
        public string MailboxPicking { get; set; }
        public DateTime MailboxPickingDate { get; set; }
        public string RecommendationLevel { get; set; }
        public string NonMachinable { get; set; }
        public string DeliveryAvisage { get; set; }
        public string DeliveryInstructions1 { get; set; }
        public string DeliveryInstructions2 { get; set; }
        public string DeliveryInstructions3 { get; set; }
        public string DeliveryRelayCountryCode { get; set; }
        public string DeliveryRelayNumber { get; set; }
        public string DeliveryReturn { get; set; }
        public string DeliveryMontage { get; set; }
        public string PickupLocationId { get; set; }
        public string RecipCompanyName { get; set; }
        public string RecipStreetNumber { get; set; }
        public string RecipAddr0 { get; set; }
        public string RecipAddr1 { get; set; }
        public string RecipAddr2 { get; set; }
        public string RecipAddr3 { get; set; }
        public string RecipStateProvinceCode { get; set; }
        public string RecipZip { get; set; }
        public string RecipCity { get; set; }
        public string RecipCountryIsocode { get; set; }
        public string RecipPhoneNumber { get; set; }
        public string RecipMobileNumber { get; set; }
        public string RecipFirstName { get; set; }
        public string RecipLastName { get; set; }
        public string RecipEmail { get; set; }
        public string RecipCompanyCode { get; set; }
        public string RecipCustomerCode { get; set; }
        public string RecipLanguageCode { get; set; }
        public string RecipCountryLib { get; set; }
        public string RecipDoorCode1 { get; set; }
        public string RecipDoorCode2 { get; set; }
        public string RecipIntercom { get; set; }
        public string RecipStage { get; set; }
        public string RecipInhabitationType { get; set; }
        public string RecipElevator { get; set; }
        public string SenderName { get; set; }
        public string SenderStreetNumber { get; set; }
        public string SenderAddr0 { get; set; }
        public string SenderAddr1 { get; set; }
        public string SenderAddr2 { get; set; }
        public string SenderAddr3 { get; set; }
        public string SenderStateProvinceCode { get; set; }
        public string SenderZip { get; set; }
        public string SenderCity { get; set; }
        public string SenderCountryLib { get; set; }
        public string SendercountryCode { get; set; }
        public string SenderDoorCode1 { get; set; }
        public string SenderDoorCode2 { get; set; }
        public string Senderintercom { get; set; }
        public string SenderRelayCountry { get; set; }
        public string SenderRelayNumber { get; set; }
        public string SenderCompanyName { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string SenderEmail { get; set; }
        public string ProductCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStatus { get; set; }
        public string ErrorCode { get; set; }
        public string ProductCategory { get; set; }
        public string SenderParcelRef { get; set; }
        public string CustomsDeclarations { get; set; }
        public byte[] CustomsDeclarationsBase64 { get; set; }
        public string CustomDeclarationPath { get; set; }
        public string Edistatus { get; set; }
        public string ParcelLenght { get; set; }
        public string ParcelLength { get; set; }
        public string ParcelHeight { get; set; }
        public string ParcelWidth { get; set; }
        public string ParcelSizeCode { get; set; }
        public string ParcelVolume { get; set; }
        public int? WarehouseId { get; set; }
        public string InsurranceYn { get; set; }
        public string InsurranceCurrency { get; set; }
        public string ParcelValueCurrency { get; set; }
        public string LabelFileFormat { get; set; }
        public int? LabelX { get; set; }
        public int? LabelY { get; set; }
        public int? ParcelShipmentSequence { get; set; }
        public string ShipmentIdentificationNumber { get; set; }
        public string TrackingInfo { get; set; }
        public string ShippingAmount { get; set; }
        public string ParcelNumberPartner { get; set; }
        public string ShippingTax { get; set; }
        public string SpecialServiceTypeCode { get; set; }
        public string CustomContent { get; set; }
        public string NumberOfPieces { get; set; }
        public string ProvisionnalShippingPrice { get; set; }
        public DateTime? CreatedFromWmstimeStamp { get; set; }
        public DateTime? StatusUpdateFromWmstimeStamp { get; set; }
        public string Wmskey { get; set; }
        public string Eorinumber { get; set; }
        public decimal? ShippingCostPrice { get; set; }
        public decimal? ShippingPublicPrice { get; set; }
        public string WeightUnit { get; set; }
        public string LenghtUnit { get; set; }
        public string UnitOfMeasurement { get; set; }

        public virtual ICollection<DeliveryProduct> DeliveryProducts { get; set; }
    }
}
