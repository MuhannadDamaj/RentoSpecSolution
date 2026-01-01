using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class Branch : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Code { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(1000)]
        public string Notes { get; set; }
        public bool IsActive { get; set; } = true;

        // FK to Company
        [Required]
        public int CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public Company Company { get; set; }

    }
}
