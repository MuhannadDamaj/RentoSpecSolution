using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class User : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FullName { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [Length(10, 20)]
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
        public int CompanyID { get; set; }
        [Required]
        public int BranchID { get; set; }
        [ForeignKey("BranchID")]
        public virtual Branch Branch { get; set; }

    }
}
