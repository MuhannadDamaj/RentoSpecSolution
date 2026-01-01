using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class CompanyDto : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Logo { get; set; }
        public byte[]? LogoBytes { get; set; }
        [Required]
        [EmailAddress]
        public string DesignatedEmail { get; set; }
        [Required]
        public string TermsAndConditionsMessage { get; set; }
        [Required]
        public string CheckInEmailTemplate { get; set; }
        [Required]
        public string CheckOutEmailTemplate { get; set; }
        [Required]
        public string PartialCheckOutEmailTemplate { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public int CurrencyID { get; set; }
    }
}
