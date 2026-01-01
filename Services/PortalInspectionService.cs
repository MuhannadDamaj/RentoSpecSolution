using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;
namespace RentospectWebAPI.Services
{
    public class PortalInspectionService
    {
        public PortalInspectionService(RentospectContext rentospectContext)
        {
            RentospectContext = rentospectContext;
        }

        public RentospectContext RentospectContext { get; }
        public async Task<InspectionDto[]> GetInspectionsByCompanyIdAsync(int companyID)
        {
            InspectionDto[] inspections = await RentospectContext.Inspections
                                                                .Where(insp => insp.CompanyID == companyID)
                                                                .AsNoTracking()
                                                                .Select(inspect => new InspectionDto
                                                                {
                                                                    CarID = inspect.CarID,
                                                                    UserID = inspect.UserID,
                                                                    CompanyID = companyID,
                                                                    AgreementNumber = inspect.AgreementNumber,
                                                                    CheckType = inspect.CheckType,
                                                                    DriverEmail = inspect.DriverEmail,
                                                                    DriverName = inspect.DriverName,
                                                                    ID = inspect.ID,
                                                                    InspectionDate = inspect.InspectionDate,
                                                                    InspectionNumber = inspect.InspectionNumber,
                                                                    InspectionTypeID = inspect.InspectionTypeID,
                                                                    IsActive = inspect.IsActive,
                                                                    IsPending = inspect.IsPending,
                                                                    IsTermsAndConditionsAgreed = inspect.IsTermsAndConditionsAgreed,
                                                                    PlateNumber = inspect.PlateNumber,
                                                                    SignatureBase64 = inspect.SignatureBase64,
                                                                    Status = inspect.Status,
                                                                }).ToArrayAsync();
            foreach (var inspection in inspections)
            {
                Car? car = RentospectContext.Cars.FirstOrDefault(car => car.ID == inspection.CarID);
                if (car != null)
                {
                    inspection.CarMake = car.CarMake;
                    inspection.CarMVA_Number = car.MVA_Number;
                    inspection.CarPlateNumber = car.PlateNumber;
                    inspection.CarColor = car.Color;
                    inspection.CarModel = car.CarModel;
                }
                User? user = RentospectContext.Users.FirstOrDefault(usr => usr.ID == inspection.UserID);
                if (user != null)
                    inspection.UserFullName = user.FullName;
                Company? company = RentospectContext.Companies.FirstOrDefault(cmp => cmp.ID == inspection.CompanyID);
                if (company != null)
                    inspection.CompanyName = company.Name;
            }
            return inspections;
        }
    }
}
