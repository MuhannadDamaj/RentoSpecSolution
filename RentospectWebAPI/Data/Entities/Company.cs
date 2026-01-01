using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class Company : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Logo { get; set; }
        public byte[]? LogoBytes { get; set; }
        [Required]
        [EmailAddress]
        public string DesignatedEmail { get; set; }
        public string TermsAndConditionsMessage { get; set; }
        public string CheckInEmailTemplate { get; set; }
        public string CheckOutEmailTemplate { get; set; }
        public string PartialCheckOutEmailTemplate { get; set; }
        public bool IsActive { get; set; } = true;

        [Required]
        public int CurrencyID { get; set; }
        [ForeignKey("CurrencyID")]
        public virtual Currency Currency { get; set; }
    }
}
