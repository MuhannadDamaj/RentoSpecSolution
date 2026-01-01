using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RentospectShared.DTOs
{
    public class CarClassDamageDto : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public int CarClassID { get; set; }
        [Required]
        public int DamageID { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
