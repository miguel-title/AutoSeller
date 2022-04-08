using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string MPN { get; set; }
        public string ProductIdExt { get; set; }
        public string ProductName { get; set; }
        public string StoreKey { get; set; }
        public string MerchantKey { get; set; }
        public int? MerchantId { get; set; }
        public string Active { get; set; }
        public string PriceInclTax { get; set; }
        public string Tax { get; set; }
        public string PriceExclTax { get; set; }
        public string TaxRate { get; set; }
        public string Weight { get; set; }
        public int? Cn23categoryId { get; set; }
        public string Gtin { get; set; }
        public string ProductWidth { get; set; }
        public string ProductDepth { get; set; }
        public string ProductLength { get; set; }
        public string VariationId { get; set; }
        public string BundleId { get; set; }
        public string FamilyKey { get; set; }
        public string FamilyName { get; set; }
        public string IndustrialId { get; set; }
        public string Industrial { get; set; }
        public string IndustrialRestocking { get; set; }
        public DateTime? PutSaleDate { get; set; }
        public DateTime? EndSaleDate { get; set; }
        public string CartonDimension { get; set; }
        public string CartonGtin { get; set; }
        public string CartonRef { get; set; }
        public int? CartonWeight { get; set; }
        public int? CartonFloor { get; set; }
        public string CartonBunchingProtocol { get; set; }
        public int? PalletWeight { get; set; }
        public int? TotalProductsStock { get; set; }
        public int? StockMini { get; set; }
        public int? StockMaxi { get; set; }
        public int? StockAlert { get; set; }
        public int? StockMax { get; set; }
        public int? StockBuffer { get; set; }
        public int? CartonsPerPaletNb { get; set; }
        public int? PalletFloor { get; set; }
        public int? ReservedStock { get; set; }
        public string Fragility { get; set; }
        public string BuyingUnitCode { get; set; }
        public string BuyingUnitName { get; set; }
        public string SalesUnitCode { get; set; }
        public string SalesUnitName { get; set; }
        public int? NbProductsPerBuyingUnit { get; set; }
        public int? NbProductsPerSalesUnit { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Hscode { get; set; }
        public DateTime? ProductToWmstimeStamp { get; set; }
        public DateTime? StockUpdateFromWmstimeStamp { get; set; }
        public string Wmskey { get; set; }
    }
}
