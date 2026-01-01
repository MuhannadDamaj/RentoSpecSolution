using System.ComponentModel.DataAnnotations;

namespace RentospectWebAPI.Data.Entities
{
    public class CarCategory : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
