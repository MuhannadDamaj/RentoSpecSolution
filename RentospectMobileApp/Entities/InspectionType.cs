using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("InspectionType")]
    public class InspectionType : AuditableEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RecommendationMessage { get; set; }
    }
}
