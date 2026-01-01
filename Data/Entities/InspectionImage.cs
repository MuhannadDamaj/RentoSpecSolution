using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class InspectionImage
    {
        [Key]
        public Guid ID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int OrderIndex { get; set; }
        public Guid InspectionID { get; set; }
        [ForeignKey("InspectionID")]
        public Inspection Inspection { get; set; }
        public bool IsActive { get; set; }
    }
}
