using RentospectWebAPI.Data.CommonEnum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class InspectionDamage
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid InspectionID { get; set; }
        [ForeignKey("InspectionID")]
        public Inspection Inspection { get; set; }
        [Required]
        public int DamageID { get; set; }
        [ForeignKey("DamageID")]
        public Damage Damage { get; set; }
        public InspectionCheckTypeEnum CheckType { get; set; }
    }
}
