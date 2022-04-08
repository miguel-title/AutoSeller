using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTCD001
{
    public partial class CarrierProductSetting
    {
        public int CarrierProductSettingsId { get; set; }
        public int CarrierProductId { get; set; }
        public string ContractId { get; set; }
        public string Password { get; set; }
        public string AccountId { get; set; }
        public string DefaultDepositDelay { get; set; }
        public string DefaultPickupLocation { get; set; }
        public string DefaultWeight { get; set; }
        public string DefaultSenderPrinter { get; set; }
        public string DefaultSenderCompanyName { get; set; }
        public string DefaultSenderContactName { get; set; }
        public string DefaultSenderContactEmail { get; set; }
        public string DefaultSenderContactPhone { get; set; }
        public string DefaultSenderAdr1 { get; set; }
        public string DefaultSenderAdr2 { get; set; }
        public string DefaultSenderAdr3 { get; set; }
        public string DefaultSenderZipCode { get; set; }
        public string DefaultSenderCity { get; set; }
        public string DefaultSenderCountry { get; set; }
        public string DefaultSenderCountryCode { get; set; }
        public bool? EdionOff { get; set; }
        public string EdifilePrefix { get; set; }
        public string Edidirectory { get; set; }
        public TimeSpan? EdisendingTime1 { get; set; }
        public TimeSpan? EdisendingTime2 { get; set; }
        public TimeSpan? EdisendingTime3 { get; set; }
        public TimeSpan? EdisendingTime4 { get; set; }
        public TimeSpan? EdisendingTime5 { get; set; }
        public TimeSpan? EdisendingTime6 { get; set; }
        public TimeSpan? EdisendingTime7 { get; set; }
        public TimeSpan? EdisendingTime8 { get; set; }
        public string EdicodeEnseigne { get; set; }
        public string Edilibenseigne { get; set; }
        public string EdireferenceExpedition { get; set; }
        public string EdixeettrelaisOuCodeSecteur { get; set; }
        public string EdiidentifiantClient { get; set; }
        public string EdimodeReglement { get; set; }
        public string EdicodeEnregistrement { get; set; }
        public string EdicodeSocieteEmettrice { get; set; }
        public string EdilibelleSocieteEmettrice { get; set; }
        public string EdicodeSocieteReceptrice { get; set; }
        public string EdilibelleSocieteReceptrice { get; set; }
        public string EdicodeTypeDeDonnees { get; set; }
        public string EdilibelleTypeDonnees { get; set; }
        public string EdinumeroDeVersion { get; set; }
        public DateTime? EdidateConstitutionApplicativeDuFichier { get; set; }
        public DateTime? EdidateValeurDonnees { get; set; }
        public string EdinsequenceFichierDansLeType { get; set; }
        public string EdilastFileSuffix { get; set; }
        public DateTime? EdilastFileTimeStamp { get; set; }
        public string EdiftpUrl { get; set; }
        public string EdiftpUser { get; set; }
        public string EdiftpPassword { get; set; }
        public string EdicodeSite { get; set; }
        public string EdiincrementValeurRefEnseigne { get; set; }
        public int? EdicurrentParcelRank { get; set; }
        public bool? EdicurrentParcelRankWorking { get; set; }
        public bool RelayAuto { get; set; }
        public string CollectionMode { get; set; }
        public string LabelPathRules { get; set; }
        public string DefaultSigned { get; set; }
        public string DefaultSpecialServiceTypeCode { get; set; }
        public string UserName { get; set; }
        public string LabellerCode { get; set; }
        public string DefaultProductCode { get; set; }
        public string DefaultSenderStreetNumber { get; set; }
        public string AuthentificationUser { get; set; }
        public string AuthentificationSignature { get; set; }
    }
}
