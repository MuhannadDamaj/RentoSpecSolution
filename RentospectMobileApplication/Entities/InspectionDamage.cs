using RentospectShared.CommonEnum;
using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("InspectionDamage")]
    public class InspectionDamage
    {
        [PrimaryKey]
        public Guid ID { get; set; }
        public Guid InspectionID { get; set; }
        public string PartName { get; set; }
        public string ListOfDamages { get; set; }
        public double DamageSeverityScore { get; set; }
        public string LaborOperation { get; set; }
        public double ConfidenceScore { get; set; }
        public double PaintLaborUnits { get; set; }
        public double RemovalRefitUnits { get; set; }
        public double LaborRepairUnits { get; set; }
    }
}
