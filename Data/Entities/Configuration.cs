using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentospectWebAPI.Data.Entities
{
    public class Configuration: AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        public int RequiredNumberOfPhotos { get; set; } = 12;
        public bool IsBranchCodeRequired { get; set; } = false;
        // FK to Company
        [Required]
        public int CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public Company Company { get; set; }
    }
}
