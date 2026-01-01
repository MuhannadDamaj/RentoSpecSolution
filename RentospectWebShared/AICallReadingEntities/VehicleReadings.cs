using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.AICallReadingEntities
{
    public class VehicleReadings
    {
        public string OdometerReading { get; set; }
        public string VinReading { get; set; }
        public string FuelMeterReading { get; set; }
        public string LicensePlateReading { get; set; }
        public string EngineNumberReading { get; set; }
        public string Observations { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SubModel { get; set; }
        public string Color { get; set; }
        public double LaborHoursEstimate { get; set; }
    }
}
