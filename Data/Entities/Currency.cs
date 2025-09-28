using System.ComponentModel.DataAnnotations;

namespace RentospectWebAPI.Data.Entities
{
    public class Currency: AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Symbol { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
