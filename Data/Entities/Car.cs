using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;

namespace RentospectWebAPI.Data.Entities
{
    public class Car : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string PlateNumber { get; set; }
        [Required]
        public int Year { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        public string MVA_Number { get; set; }
        [Required]
        public string CarMake { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        public int CarClassId { get; set; }
        [ForeignKey(nameof(CarClassId))]
        public virtual CarClass CarClass { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
