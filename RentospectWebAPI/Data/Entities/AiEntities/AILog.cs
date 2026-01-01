using System.ComponentModel.DataAnnotations;

namespace RentospectWebAPI.Data.Entities.AiEntities
{
    public class AILog
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public string InspectionJson { get; set; } // Stores full JSON payload

        public DateTime ReceivedAt { get; set; } = DateTime.Now;
    }
}
