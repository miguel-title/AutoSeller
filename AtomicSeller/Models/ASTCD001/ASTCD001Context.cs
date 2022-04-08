using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class ASTCD001Context : DbContext
    {
        public ASTCD001Context()
        {
        }

        public ASTCD001Context(DbContextOptions<ASTCD001Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AtomicSetting> AtomicSettings { get; set; }
        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<CarrierProduct> CarrierProducts { get; set; }
        public virtual DbSet<CarrierProductSetting> CarrierProductSettings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<DeliveryPackage> DeliveryPackages { get; set; }
        public virtual DbSet<DeliveryProduct> DeliveryProducts { get; set; }
        public virtual DbSet<Edierror> Edierrors { get; set; }
        public virtual DbSet<ExportFile> ExportFiles { get; set; }
        public virtual DbSet<ExportFileColumn> ExportFileColumns { get; set; }
        public virtual DbSet<ImportHeader> ImportHeaders { get; set; }
        public virtual DbSet<ImportLinesLog> ImportLinesLogs { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceTemplate> InvoiceTemplates { get; set; }
        public virtual DbSet<LabelsTemplate> LabelsTemplates { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDelivery> OrderDeliveries { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductLot> ProductLots { get; set; }
        public virtual DbSet<ProductVariation> ProductVariations { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<StockInput> StockInputs { get; set; }
        public virtual DbSet<StockInputProduct> StockInputProducts { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreCsopistatus> StoreCsopistatuses { get; set; }
        public virtual DbSet<StoreEdisetting> StoreEdisettings { get; set; }
        public virtual DbSet<StoreShippingSetting> StoreShippingSettings { get; set; }
        public virtual DbSet<StoreStatusSetting> StoreStatusSettings { get; set; }
        public virtual DbSet<TaxRate> TaxRates { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Wm> Wms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=tcp:testv3.atomicseller.com,1433;Database=ASTCD017;User Id=P987456HGIYTELJH456BK5678;Password=KLHFJ657496%4RF!KVI76RFO8;MultipleActiveResultSets=true;");
                optionsBuilder.UseSqlServer("Server=tcp:testv3.atomicseller.com,1433;Database=ASTCD005;User Id=P987456HGIYTELJH456BK5678;Password=KLHFJ657496%4RF!KVI76RFO8;MultipleActiveResultSets=true;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<AtomicSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("AtomicSetting");

                entity.Property(e => e.SettingId).HasColumnName("Setting_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KeyColumn)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Value).HasMaxLength(2048);
            });

            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.ToTable("AuditTrail");

                entity.Property(e => e.AuditTrailId).HasColumnName("AuditTrailID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.ToTable("Carrier");

                entity.Property(e => e.CarrierId)
                    .ValueGeneratedNever()
                    .HasColumnName("Carrier_ID");

                entity.Property(e => e.CarrierName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CarrierProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("CarrierProduct");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.CarrierId).HasColumnName("Carrier_ID");

                entity.Property(e => e.CarrierServiceKey)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CarrierProductSetting>(entity =>
            {
                entity.HasKey(e => e.CarrierProductSettingsId);

                entity.Property(e => e.CarrierProductSettingsId).HasColumnName("CarrierProductSettingsID");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.AuthentificationSignature)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("authentification_Signature");

                entity.Property(e => e.AuthentificationUser)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("authentification_User");

                entity.Property(e => e.CarrierProductId).HasColumnName("CarrierProductID");

                entity.Property(e => e.CollectionMode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContractId)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ContractID");

                entity.Property(e => e.DefaultDepositDelay)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultPickupLocation)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultProductCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSenderAdr1).HasMaxLength(50);

                entity.Property(e => e.DefaultSenderAdr2).HasMaxLength(50);

                entity.Property(e => e.DefaultSenderAdr3).HasMaxLength(50);

                entity.Property(e => e.DefaultSenderCity).HasMaxLength(50);

                entity.Property(e => e.DefaultSenderCompanyName).HasMaxLength(50);

                entity.Property(e => e.DefaultSenderContactEmail).HasMaxLength(128);

                entity.Property(e => e.DefaultSenderContactName).HasMaxLength(80);

                entity.Property(e => e.DefaultSenderContactPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSenderCountry).HasMaxLength(50);

                entity.Property(e => e.DefaultSenderCountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSenderPrinter)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSenderStreetNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSenderZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSigned)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSpecialServiceTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultWeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EdicodeEnregistrement)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDICodeEnregistrement");

                entity.Property(e => e.EdicodeEnseigne)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("EDICodeEnseigne");

                entity.Property(e => e.EdicodeSite)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("EDICodeSite");

                entity.Property(e => e.EdicodeSocieteEmettrice)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDICodeSocieteEmettrice");

                entity.Property(e => e.EdicodeSocieteReceptrice)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDICodeSocieteReceptrice");

                entity.Property(e => e.EdicodeTypeDeDonnees)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDICodeTypeDeDonnees");

                entity.Property(e => e.EdicurrentParcelRank).HasColumnName("EDICurrentParcelRank");

                entity.Property(e => e.EdicurrentParcelRankWorking).HasColumnName("EDICurrentParcelRankWorking");

                entity.Property(e => e.EdidateConstitutionApplicativeDuFichier)
                    .HasColumnType("datetime")
                    .HasColumnName("EDIDateConstitutionApplicativeDuFichier");

                entity.Property(e => e.EdidateValeurDonnees)
                    .HasColumnType("datetime")
                    .HasColumnName("EDIDateValeurDonnees");

                entity.Property(e => e.Edidirectory)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDIDirectory");

                entity.Property(e => e.EdifilePrefix)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EDIFilePrefix");

                entity.Property(e => e.EdiftpPassword)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("EDIFtpPassword");

                entity.Property(e => e.EdiftpUrl)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("EDIFtpURL");

                entity.Property(e => e.EdiftpUser)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("EDIFtpUser");

                entity.Property(e => e.EdiidentifiantClient)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EDIIdentifiantClient");

                entity.Property(e => e.EdiincrementValeurRefEnseigne)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EDIIncrementValeurRefEnseigne");

                entity.Property(e => e.EdilastFileSuffix)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDILastFileSuffix");

                entity.Property(e => e.EdilastFileTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("EDILastFileTimeStamp");

                entity.Property(e => e.EdilibelleSocieteEmettrice)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDILibelleSocieteEmettrice");

                entity.Property(e => e.EdilibelleSocieteReceptrice)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDILibelleSocieteReceptrice");

                entity.Property(e => e.EdilibelleTypeDonnees)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDILibelleTypeDonnees");

                entity.Property(e => e.Edilibenseigne)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EDILIBEnseigne");

                entity.Property(e => e.EdimodeReglement)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EDIModeReglement");

                entity.Property(e => e.EdinsequenceFichierDansLeType)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDINSequenceFichierDansLeType");

                entity.Property(e => e.EdinumeroDeVersion)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("EDINumeroDeVersion");

                entity.Property(e => e.EdionOff).HasColumnName("EDIOnOff");

                entity.Property(e => e.EdireferenceExpedition)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EDIReferenceExpedition");

                entity.Property(e => e.EdisendingTime1).HasColumnName("EDISendingTime1");

                entity.Property(e => e.EdisendingTime2).HasColumnName("EDISendingTime2");

                entity.Property(e => e.EdisendingTime3).HasColumnName("EDISendingTime3");

                entity.Property(e => e.EdisendingTime4).HasColumnName("EDISendingTime4");

                entity.Property(e => e.EdisendingTime5).HasColumnName("EDISendingTime5");

                entity.Property(e => e.EdisendingTime6).HasColumnName("EDISendingTime6");

                entity.Property(e => e.EdisendingTime7).HasColumnName("EDISendingTime7");

                entity.Property(e => e.EdisendingTime8).HasColumnName("EDISendingTime8");

                entity.Property(e => e.EdixeettrelaisOuCodeSecteur)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EDIXEETTRelaisOuCodeSecteur");

                entity.Property(e => e.LabelPathRules).IsUnicode(false);

                entity.Property(e => e.LabellerCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Active)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Address0)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Address1)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.BuyerMainMkPlc).HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.CountryIsocode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CountryISOCode");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerBuyerUserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Customer_BuyerUserID");

                entity.Property(e => e.Email1).HasMaxLength(128);

                entity.Property(e => e.Email2)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StateProvince)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Vip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("VIP");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");

                entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");

                entity.Property(e => e.CarrierServiceKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedFromWmstimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedFromWMSTimeStamp");

                entity.Property(e => e.CustomContent)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CustomDeclarationPath).HasMaxLength(1024);

                entity.Property(e => e.CustomsDeclarations)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryAvisage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryInstructions1).HasColumnType("ntext");

                entity.Property(e => e.DeliveryInstructions2).HasMaxLength(50);

                entity.Property(e => e.DeliveryInstructions3).HasMaxLength(50);

                entity.Property(e => e.DeliveryMontage)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryRelayCountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryRelayNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryReturn)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DepositDate).HasColumnType("datetime");

                entity.Property(e => e.Edistatus)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EDIStatus");

                entity.Property(e => e.Eorinumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EORINumber");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage).HasColumnType("text");

                entity.Property(e => e.ErrorStatus)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InsurranceCurrency)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InsurranceYn)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("InsurranceYN");

                entity.Property(e => e.LabelFileFormat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabelPath)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.LenghtUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MailboxPicking)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MailboxPickingDate).HasColumnType("datetime");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.NonMachinable)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("nonMachinable");

                entity.Property(e => e.NumberOfPieces)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelHeight)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelInsuranceValue)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelLenght)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelLength)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelNumberPartner)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("parcelNumberPartner");

                entity.Property(e => e.ParcelSizeCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelValue)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelValueCurrency)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelVolume)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelWidth)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PickupLocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pickupLocationId");

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvisionnalShippingPrice)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipAddr0).HasMaxLength(80);

                entity.Property(e => e.RecipAddr1).HasMaxLength(80);

                entity.Property(e => e.RecipAddr2).HasMaxLength(80);

                entity.Property(e => e.RecipAddr3).HasMaxLength(80);

                entity.Property(e => e.RecipCity).HasMaxLength(50);

                entity.Property(e => e.RecipCompanyCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.RecipCompanyName).HasMaxLength(50);

                entity.Property(e => e.RecipCountryIsocode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RecipCountryISOCode");

                entity.Property(e => e.RecipCountryLib).HasMaxLength(50);

                entity.Property(e => e.RecipCustomerCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipDoorCode1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipDoorCode2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipElevator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipEmail).HasMaxLength(128);

                entity.Property(e => e.RecipFirstName).HasMaxLength(50);

                entity.Property(e => e.RecipInhabitationType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipIntercom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipLanguageCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipLastName).HasMaxLength(50);

                entity.Property(e => e.RecipMobileNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecipPhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecipStage)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipStateProvinceCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecipStreetNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecipZip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendationLevel)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("recommendationLevel");

                entity.Property(e => e.Return)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SenderAddr0).HasMaxLength(80);

                entity.Property(e => e.SenderAddr1).HasMaxLength(80);

                entity.Property(e => e.SenderAddr2).HasMaxLength(80);

                entity.Property(e => e.SenderAddr3).HasMaxLength(80);

                entity.Property(e => e.SenderCity).HasMaxLength(50);

                entity.Property(e => e.SenderCompanyName).HasMaxLength(50);

                entity.Property(e => e.SenderCountryLib).HasMaxLength(50);

                entity.Property(e => e.SenderDoorCode1)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SenderDoorCode2)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SenderEmail).HasMaxLength(128);

                entity.Property(e => e.SenderName).HasMaxLength(50);

                entity.Property(e => e.SenderParcelRef)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senderParcelRef");

                entity.Property(e => e.SenderPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SenderRelayCountry).HasMaxLength(50);

                entity.Property(e => e.SenderRelayNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SenderStateProvinceCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SenderStreetNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SenderZip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendercountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Senderintercom)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShipmentIdentificationNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShipmentStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingCostPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShippingDate).HasColumnType("datetime");

                entity.Property(e => e.ShippingMethodId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Shipping_method_id");

                entity.Property(e => e.ShippingMethodTitle)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("Shipping_method_title");

                entity.Property(e => e.ShippingPublicPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShippingServiceId).HasColumnName("ShippingServiceID");

                entity.Property(e => e.ShippingTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Signed)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialServiceTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StatusUpdateFromWmstimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("StatusUpdateFromWMSTimeStamp");

                entity.Property(e => e.TrackingInfo).HasColumnType("ntext");

                entity.Property(e => e.TrackingNumber)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.UnitOfMeasurement)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.Property(e => e.WeightUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Wmskey)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("WMSKey");
            });

            modelBuilder.Entity<DeliveryPackage>(entity =>
            {
                entity.ToTable("DeliveryPackage");

                entity.Property(e => e.DeliveryPackageId).HasColumnName("DeliveryPackageID");

                entity.Property(e => e.CustomerReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");

                entity.Property(e => e.Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InsurredValue)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabelPath)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Length)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PackagingDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Width)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeliveryProduct>(entity =>
            {
                entity.ToTable("DeliveryProduct");

                entity.Property(e => e.DeliveryProductId).HasColumnName("DeliveryProductID");

                entity.Property(e => e.BestBeforeDate).HasColumnType("datetime");

                entity.Property(e => e.BundleId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BundleID");

                entity.Property(e => e.Cn23categoryId).HasColumnName("CN23CategoryID");

                entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");

                entity.Property(e => e.DeliveryPackageId).HasColumnName("DeliveryPackageID");

                entity.Property(e => e.DeliveryShipmentId).HasColumnName("DeliveryShipmentID");

                entity.Property(e => e.Depth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Eancode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EANCode");

                entity.Property(e => e.Hscode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("HSCode");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ItemID");

                entity.Property(e => e.Length)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PriceExclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductLotKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.SubTotalPriceExclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotalTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VariationId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VariationID");

                entity.Property(e => e.Weight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Width)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.DeliveryProducts)
                    .HasForeignKey(d => d.DeliveryId)
                    .HasConstraintName("FK_DeliveryProduct_Delivery");
            });

            modelBuilder.Entity<Edierror>(entity =>
            {
                entity.ToTable("EDIError");

                entity.Property(e => e.EdierrorId).HasColumnName("EDIErrorID");

                entity.Property(e => e.AlertSent)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.OrderKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderProductKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShipmentKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExportFile>(entity =>
            {
                entity.ToTable("ExportFile");

                entity.Property(e => e.ExportFileId)
                    .ValueGeneratedNever()
                    .HasColumnName("ExportFileID");

                entity.Property(e => e.PrimaryKeyDatabaseField).HasColumnType("text");

                entity.Property(e => e.Title).HasColumnType("text");
            });

            modelBuilder.Entity<ExportFileColumn>(entity =>
            {
                entity.ToTable("ExportFileColumn");

                entity.Property(e => e.ExportFileColumnId)
                    .ValueGeneratedNever()
                    .HasColumnName("ExportFileColumnID");

                entity.Property(e => e.DataBaseField).HasColumnType("text");

                entity.Property(e => e.ExportFileId).HasColumnName("ExportFileID");

                entity.Property(e => e.FileField).HasColumnType("text");
            });

            modelBuilder.Entity<ImportHeader>(entity =>
            {
                entity.Property(e => e.ImportHeaderId).HasColumnName("ImportHeaderID");

                entity.Property(e => e.HeaderExternalName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderInternalName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.StoreKey)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImportLinesLog>(entity =>
            {
                entity.HasKey(e => e.ImportLineId)
                    .HasName("PK_ImportLines");

                entity.ToTable("ImportLinesLog");

                entity.Property(e => e.ImportLineId).HasColumnName("ImportLineID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ImportFileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.User)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.BillingAdr0)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.BillingAdr1)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.BillingAdr2)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCity)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCompany)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCountry)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCountryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BillingEmail)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.BillingFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillingLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillingPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillingState)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.BillingZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerMarking).HasColumnName("customerMarking");

                entity.Property(e => e.DelTerms).HasColumnName("delTerms");

                entity.Property(e => e.DelTransportTerms).HasColumnName("delTransportTerms");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvoicePath)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrderReference)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("orderReference");

                entity.Property(e => e.PayTerms).HasColumnName("payTerms");

                entity.Property(e => e.Salesman)
                    .HasMaxLength(50)
                    .HasColumnName("salesman");

                entity.Property(e => e.TotalAmount)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalExclVat)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TotalExclVAT");

                entity.Property(e => e.TotalShipping)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalVat)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TotalVAT");
            });

            modelBuilder.Entity<InvoiceTemplate>(entity =>
            {
                entity.ToTable("InvoiceTemplate");

                entity.Property(e => e.InvoiceTemplateId).HasColumnName("InvoiceTemplateID");

                entity.Property(e => e.DefaultCurrency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultDelTerms).HasColumnType("text");

                entity.Property(e => e.DefaultDelTransportTerms).HasColumnType("text");

                entity.Property(e => e.DefaultPayTerms).HasColumnType("text");

                entity.Property(e => e.LastInvoiceNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyAdr1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyAdr2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyAdr3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyCity)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyCountry)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyEmail)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyLegalInfo).HasColumnType("text");

                entity.Property(e => e.SellerCompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SellerCompanyZip)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LabelsTemplate>(entity =>
            {
                entity.HasKey(e => e.TemplateId);

                entity.ToTable("LabelsTemplate");

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.Property(e => e.ColNb)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ColSpacing)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ColWidth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DrawLines)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabelHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageBottomMargin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageFooterHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageHeaderHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageHeight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageLeftMargin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageRightMargin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageTopMargin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PageWidth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row1Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row1FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row1FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row1Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row1Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row2Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row2FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row2FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row2Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row2Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row3Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row3FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row3FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row3Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row3Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row4Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row4FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row4FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row4Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row4Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row5Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row5FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row5FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row5Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row5Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row6Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row6FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row6FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row6Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row6Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row7Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row7FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row7FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row7Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row7Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Row8Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Row8FontSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row8FontWeight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Row8Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row8Text)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RowNb)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RowSpacing)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RowsPerLabel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.ToTable("Merchant");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantName).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.AddressStreet1)
                    .HasMaxLength(80)
                    .HasColumnName("Address_Street1");

                entity.Property(e => e.AddressStreet2)
                    .HasMaxLength(80)
                    .HasColumnName("Address_Street2");

                entity.Property(e => e.AddressStreet3)
                    .HasMaxLength(80)
                    .HasColumnName("Address_Street3");

                entity.Property(e => e.BuyerSEmail)
                    .HasMaxLength(128)
                    .HasColumnName("Buyer_s_email");

                entity.Property(e => e.BuyerSPhone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Buyer_s_Phone");

                entity.Property(e => e.CheckoutMessage).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomContent)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLanguageCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryAddr0)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryAddr1)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryAddr2)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryAddr3)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryCity)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryCompanyName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryCountryIsocode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DeliveryCountryISOCode");

                entity.Property(e => e.DeliveryCountryName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryEmail)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryFirstName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryLastName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryMobile)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryPhone)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryRelayCountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryRelayNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryStreetNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EbayBuyerFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("Ebay_Buyer_first_name");

                entity.Property(e => e.EbayBuyerUserLastName)
                    .HasMaxLength(50)
                    .HasColumnName("EBAY_Buyer_UserLastName");

                entity.Property(e => e.FulfillmentChannel).HasMaxLength(50);

                entity.Property(e => e.InsurranceYn)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("InsurranceYN");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.OrderBuyerUserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Order_BuyerUserID");

                entity.Property(e => e.OrderCustomerId).HasColumnName("Order_CustomerID");

                entity.Property(e => e.OrderIdExt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OrderID_Ext");

                entity.Property(e => e.OrderKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderShipmentId).HasColumnName("Order_Shipment_ID");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("Order_Status");

                entity.Property(e => e.OrderStatusExt)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("OrderStatus_Ext");

                entity.Property(e => e.OrderToWmstimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("OrderToWMSTimeStamp");

                entity.Property(e => e.OrderType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelInsurranceValueInclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelShippingAmountInclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelValueExclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelValueInclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelValueTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Payment_Date");

                entity.Property(e => e.PaymentInfo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentReferenceId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PaymentReferenceID");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("postal_code");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Purchase_date");

                entity.Property(e => e.SalesRecordNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShipCity)
                    .HasMaxLength(50)
                    .HasColumnName("ship_city");

                entity.Property(e => e.ShipCountry)
                    .HasMaxLength(50)
                    .HasColumnName("ship_country");

                entity.Property(e => e.ShipPhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Ship_phone_number");

                entity.Property(e => e.ShipServiceLevel)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ship_service_level");

                entity.Property(e => e.ShipmentTrackingNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAddressName)
                    .HasMaxLength(50)
                    .HasColumnName("ShippingAddress_Name");

                entity.Property(e => e.ShippingCarrierUsed)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingLastName)
                    .HasMaxLength(50)
                    .HasColumnName("Shipping_last_name");

                entity.Property(e => e.ShippingPrice)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("shipping_price");

                entity.Property(e => e.ShippingServiceKey)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingServiceName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.StoreKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_Name");

                entity.Property(e => e.StoreType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Store_Type");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Transaction_ID");

                entity.Property(e => e.TransactionPrice)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Wmskey)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("WMSKey");
            });

            modelBuilder.Entity<OrderDelivery>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.DeliveryId });

                entity.ToTable("OrderDelivery");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("OrderProduct");

                entity.Property(e => e.OrderProductId).HasColumnName("OrderProductID");

                entity.Property(e => e.BestBeforeDate).HasColumnType("datetime");

                entity.Property(e => e.BundleId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BundleID");

                entity.Property(e => e.Cn23categoryId).HasColumnName("CN23CategoryID");

                entity.Property(e => e.Depth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Eancode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EANCode");

                entity.Property(e => e.Hscode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("HSCode");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ItemID");

                entity.Property(e => e.Length)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Price)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PriceExclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductLotKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.SubTotalPriceExclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotalTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VariationId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VariationID");

                entity.Property(e => e.Weight)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Width)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderProduct_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Active)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BundleId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BundleID");

                entity.Property(e => e.BuyingUnitCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BuyingUnitName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CartonBunchingProtocol)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CartonDimension)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CartonGtin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CartonGTIN");

                entity.Property(e => e.CartonRef)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cn23categoryId).HasColumnName("CN23CategoryID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndSaleDate).HasColumnType("date");

                entity.Property(e => e.FamilyKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyName).HasMaxLength(128);

                entity.Property(e => e.Fragility)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gtin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GTIN");

                entity.Property(e => e.Hscode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("HSCode");

                entity.Property(e => e.Industrial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IndustrialId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IndustrialID");

                entity.Property(e => e.IndustrialRestocking)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.PriceExclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PriceInclTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDepth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductIdExt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ProductID_Ext");

                entity.Property(e => e.ProductLength)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.ProductToWmstimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ProductToWMSTimeStamp");

                entity.Property(e => e.ProductWidth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PutSaleDate).HasColumnType("date");

                entity.Property(e => e.SalesUnitCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SalesUnitName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.StockUpdateFromWmstimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("StockUpdateFromWMSTimeStamp");

                entity.Property(e => e.StoreKey)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VariationId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VariationID");

                entity.Property(e => e.Weight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Wmskey)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("WMSKey");
            });

            modelBuilder.Entity<ProductLot>(entity =>
            {
                entity.ToTable("ProductLot");

                entity.Property(e => e.ProductLotId).HasColumnName("ProductLotID");

                entity.Property(e => e.BestBeforeDate).HasColumnType("date");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductLotIdExt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ProductLotID_Ext");

                entity.Property(e => e.ProductLotKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StockEntryDate).HasColumnType("date");
            });

            modelBuilder.Entity<ProductVariation>(entity =>
            {
                entity.ToTable("ProductVariation");

                entity.Property(e => e.ProductVariationId).HasColumnName("ProductVariationID");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Price)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Sku)
                    .HasMaxLength(10)
                    .HasColumnName("SKU")
                    .IsFixedLength(true);

                entity.Property(e => e.VariationIdext)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VariationIDExt");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.DataScopeFields).IsUnicode(false);

                entity.Property(e => e.DataScopeLimits).IsUnicode(false);

                entity.Property(e => e.OutputEmails)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.OutputFile)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.OutputGoogleSheets)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.OutputRdlc)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.OutputType)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ReportKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StockInput>(entity =>
            {
                entity.ToTable("StockInput");

                entity.Property(e => e.StockInputId).HasColumnName("StockInputID");

                entity.Property(e => e.CreateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.Property(e => e.InputKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StockInputProduct>(entity =>
            {
                entity.ToTable("StockInputProduct");

                entity.Property(e => e.StockInputProductId).HasColumnName("StockInputProductID");

                entity.Property(e => e.CellCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Decription)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SKU");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).HasColumnName("Store_ID");

                entity.Property(e => e.AmazonAccessId)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("AmazonAccessID");

                entity.Property(e => e.AmazonMarketPlaceId)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("AmazonMarketPlaceID");

                entity.Property(e => e.AmazonSecretKey)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.AmazonSellerId)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("AmazonSellerID");

                entity.Property(e => e.AppId)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("AppID");

                entity.Property(e => e.Country)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultInvoiceUrl)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("DefaultInvoiceURL");

                entity.Property(e => e.DefaultTrackingUrl)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("DefaultTrackingURL");

                entity.Property(e => e.DefaultWarehouseId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DefaultWarehouseID");

                entity.Property(e => e.EbayAuthToken)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.EdilogErrorsEmails).HasColumnName("EDILogErrorsEmails");

                entity.Property(e => e.Eorinumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EORINumber");

                entity.Property(e => e.MerchantId).HasColumnName("MerchantID");

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PriceMinisterLogin)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PriceMinisterToken)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ProviderID");

                entity.Property(e => e.ShopId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ShopID");

                entity.Property(e => e.StockManagementMode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StoreApiurl)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("StoreAPIURL");

                entity.Property(e => e.StoreEdiftpordersFile)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("StoreEDIFTPOrdersFile");

                entity.Property(e => e.StoreEdiftppassword)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("StoreEDIFTPPassword");

                entity.Property(e => e.StoreEdiftpurl)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("StoreEDIFTPURL");

                entity.Property(e => e.StoreEdiftpuser)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("StoreEDIFTPUser");

                entity.Property(e => e.StoreIdExt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("StoreID_Ext");

                entity.Property(e => e.StoreKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeLabel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wmskey)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("WMSKey");

                entity.Property(e => e.WoocommerceKey)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.WoocommerceSecret)
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StoreCsopistatus>(entity =>
            {
                entity.HasKey(e => e.CsopistatusId);

                entity.ToTable("StoreCSOPIStatus");

                entity.Property(e => e.CsopistatusId).HasColumnName("CSOPIStatusID");

                entity.Property(e => e.CsopistatusExternalName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CSOPIStatusExternalName");

                entity.Property(e => e.CsopistatusKey)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CSOPIStatusKey");

                entity.Property(e => e.CsopistatusToken)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CSOPIStatusToken");

                entity.Property(e => e.CsopistoreId).HasColumnName("CSOPIStoreID");
            });

            modelBuilder.Entity<StoreEdisetting>(entity =>
            {
                entity.HasKey(e => e.StoreSettingId);

                entity.ToTable("StoreEDISettings");

                entity.Property(e => e.StoreSettingId).HasColumnName("StoreSettingID");

                entity.Property(e => e.CheckValidDate)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CheckValidDecimal)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CheckValidEmail)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CheckValidInt)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ConditionFieldExpression)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConditionFieldName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultValue)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mandatory)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantKey)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ObjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegularExpression)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<StoreShippingSetting>(entity =>
            {
                entity.HasKey(e => e.StoreShippingSettingsId);

                entity.Property(e => e.StoreShippingSettingsId).HasColumnName("StoreShippingSettingsID");

                entity.Property(e => e.CarrierServiceKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingServiceKeywords)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.StoreKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StoreStatusSetting>(entity =>
            {
                entity.HasKey(e => e.StoreStatusId);

                entity.Property(e => e.StoreStatusId).HasColumnName("StoreStatusID");

                entity.Property(e => e.ExternalStatusRule)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.InternalStatusValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RuleKey)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<TaxRate>(entity =>
            {
                entity.ToTable("TaxRate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Lib).HasColumnType("text");

                entity.Property(e => e.Rate).HasColumnType("text");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.Property(e => e.AdrLine0)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AdrLine1)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AdrLine2)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail).HasMaxLength(1024);

                entity.Property(e => e.ContactFirstName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContactLastName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsDefault)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.WarehouseKey)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WarehouseName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wm>(entity =>
            {
                entity.HasKey(e => e.Wmsid)
                    .HasName("PK_WMS_1");

                entity.ToTable("WMS");

                entity.Property(e => e.Wmsid).HasColumnName("WMSID");

                entity.Property(e => e.FtpDefaultDir)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ftpDefaultDir");

                entity.Property(e => e.Ftppassword)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ftppassword");

                entity.Property(e => e.FtpserverUrl)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("ftpserverURL");

                entity.Property(e => e.Ftpuser)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ftpuser");

                entity.Property(e => e.WareHouseIdExt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("WareHouseID_Ext");

                entity.Property(e => e.Wmskey)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("WMSKey");

                entity.Property(e => e.Wmsname)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("WMSName");

                entity.Property(e => e.Wmstype).HasColumnName("WMSType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
