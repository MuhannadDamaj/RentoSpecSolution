using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class CarDto : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string PlateNumber { get; set; }
        [Required]
        public int Year { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        public string MVA_Number { get; set; }
        [Required]
        public string CarMake { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        public int CarClassId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
