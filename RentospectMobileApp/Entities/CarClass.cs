using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("CarClass")]
    public class CarClass : AuditableEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; }
    }
}
