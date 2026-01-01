using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class CurrencyDto : AuditableEntity
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public bool IsActive { get; set; }
    }
}
