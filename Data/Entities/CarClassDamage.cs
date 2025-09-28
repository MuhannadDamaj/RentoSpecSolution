using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class CarClassDamage : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public int CarClassID { get; set; }
        [ForeignKey("CarClassID")]
        public virtual CarClass CarClass { get; set; }
        public int DamageID { get; set; }
        [ForeignKey("DamageID")]
        public virtual Damage Damage { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
