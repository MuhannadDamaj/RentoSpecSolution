using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class MasterSyncDto
    {
        public CompanyDto[] Companies { get; set; }
        public UserDto[] Users { get; set; }
        public CarDto[] Cars { get; set; }
        public CarClassDto[] CarClasses { get; set; }
        public CarClassDamageDto[] CarClassDamages { get; set; }
        public DamageDto[] Damages { get; set; }
        public BranchDto[] Branches { get; set; }
        public InspectionResultDto[] InspectionResults { get; set; }
        public DamagedPartDto[] DamagedParts { get; set; }
        public InspectionDto[] Inspections { get; set; }
    }
}
