using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("InspectionImage")]
    public class InspectionImage
    {
        [PrimaryKey]
        public Guid ID { get; set; }
        public Guid InspectionID { get; set; }
        public string PhotoPath { get; set; }
        public int OrderIndex { get; set; } = 0;
    }
}
