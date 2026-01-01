using RentospectShared.AICallReadingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services.Contracts
{
    public interface IAIInspectionService
    {
        Task<InspectionResult> GetInspectionResultAsync();
    }
}
