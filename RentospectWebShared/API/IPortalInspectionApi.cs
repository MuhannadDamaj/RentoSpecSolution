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
    public interface IPortalInspectionApi
    {
        [Get("/api/portalinspections")]
        Task<List<InspectionDto>> GetInspectionsAsync();

        [Get("/api/portalinspections/{companyId}")]
        Task<List<InspectionDto>> GetInspectionsByCompanyIdAsync(int companyId);
    }
}
