using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    [Headers("Authorization: Bearer ")]
    public interface IInspectionResultApi
    {
        [Get("/api/inspectionresult/{inspectionId}")]
        Task<InspectionResultDto> GetInspectionResultByInspectionIDAsync(string inspectionId);
    }
}
