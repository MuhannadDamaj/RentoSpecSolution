using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("Car")]
    public class Car : AuditableEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string MVA_Number { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int CarClassId { get; set; }
    }
}
