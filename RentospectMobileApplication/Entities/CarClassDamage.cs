using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("CarClassDamage")]
    public class CarClassDamage : AuditableEntity
    {
        [PrimaryKey]
        public Guid ID { get; set; }
        public int CarClassID { get; set; }
        public int DamageID { get; set; }
        public double Price { get; set; }
    }
}
