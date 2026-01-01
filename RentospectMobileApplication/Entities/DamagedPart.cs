using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApplication.Entities
{
    [Table("DamagedPart")]
    public class DamagedPart
    {
        [PrimaryKey]
        public Guid ID { get; set; }
        public string PartName { get; set; }
        public string ListOfDamages { get; set; }
        public double DamageSeverityScore { get; set; }
        public string LaborOperation { get; set; }
        public double ConfidenceScore { get; set; }
        public double PaintLaborUnits { get; set; }
        public double RemovalRefitUnits { get; set; }
        public double LaborRepairUnits { get; set; }
        public Guid InspectionResultID { get; set; }
    }
}
