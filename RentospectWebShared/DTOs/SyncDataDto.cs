using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class SyncDataDto
    {
        public List<BranchDto> Branches { get; set; }
        public List<UserDto> Users { get; set; }
        public List<CarClassDamageDto> CarClassDamages { get; set; }
        public List<CarClassDto> CarClasses { get; set; }
        public List<CarDto> Cars { get; set; }
        public List<CompanyDto> Companies { get; set; }
        public List<DamageDto> Damages { get; set; }
    }
}
