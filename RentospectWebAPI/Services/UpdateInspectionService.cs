using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class UpdateInspectionService
    {
        private readonly RentospectContext _context;
        public UpdateInspectionService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> UpdateInspectionAsync(InspectionUpdateDto dto)
        {
            if (dto.ID == Guid.Empty)
                return CustomApiResponce.Error("Invalid Inspection ID");

            var dbInspection = await _context.Inspections
                                     .FirstOrDefaultAsync(i => i.ID == dto.ID);

            if (dbInspection == null)
                return CustomApiResponce.Error("Inspection not found");

            dbInspection.IsTermsAndConditionsAgreed = dto.IsTermsAndConditionsAgreed;
            dbInspection.Status =  RentospectShared.CommonEnum.InspactionStatusEnum.Done;
            dbInspection.IsPending = false;
            if (!string.IsNullOrEmpty(dto.SignatureBase64))
            {
                dbInspection.SignatureBase64 = dto.SignatureBase64;
            }

            _context.Inspections.Update(dbInspection);

            await _context.SaveChangesAsync();

            return CustomApiResponce.Success();
        }

    }
}
