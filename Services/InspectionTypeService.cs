using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class InspectionTypeService
    {
        public InspectionTypeService(RentospectContext rentospectContext)
        {
            RentospectContext = rentospectContext;
        }

        public RentospectContext RentospectContext { get; }

        public async Task<InspectionTypeDto[]> GetInspectionTypesAsync() => await RentospectContext.InspectionTypes
                                                                                                .Where(inspectionType => inspectionType.IsActive)
                                                                                                .AsNoTracking()
                                                                                                .Select(insType => new InspectionTypeDto
                                                                                                {
                                                                                                    ID = insType.ID,
                                                                                                    Name = insType.Name,
                                                                                                    Description = insType.Description,
                                                                                                    IsActive = insType.IsActive,
                                                                                                    CreatedAt = insType.CreatedAt,
                                                                                                    CreatedBy = insType.CreatedBy,
                                                                                                    UpdatedAt = insType.UpdatedAt,
                                                                                                    UpdatedBy = insType.UpdatedBy,
                                                                                                }).ToArrayAsync();
                                                                                               
        
    }
}
