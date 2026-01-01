using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("Company")]
    public class Company : AuditableEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public byte[]? LogoBytes { get; set; }
        public string DesignatedEmail { get; set; }
        public string TermsAndConditionsMessage { get; set; }
        public string CheckInEmailTemplate { get; set; }
        public string CheckOutEmailTemplate { get; set; }
        public string PartialCheckOutEmailTemplate { get; set; }
        public int CurrencyID { get; set; }
    }
}
