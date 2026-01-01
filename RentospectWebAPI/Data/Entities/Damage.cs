using System.ComponentModel.DataAnnotations;

namespace RentospectWebAPI.Data.Entities
{
    public class Damage : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public string ExampleOnePhoto { get; set; }
        public string ExampleTwoPhoto { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
