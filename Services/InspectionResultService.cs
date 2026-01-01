using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities.AiEntities;
using RentospectWebAPI.Data.Rentospect;
using System.Linq;

namespace RentospectWebAPI.Services
{
    public class InspectionResultService
    {

        public InspectionResultService(RentospectContext rentospectContext)
        {
            RentospectContext = rentospectContext;
        }

        public RentospectContext RentospectContext { get; }
        public async Task<InspectionResultDto?> GetInspectionResultByInspectionID(string inspectionId)
        {
            InspectionResult? inspection = await RentospectContext.InspectionResults.FirstOrDefaultAsync(insp => insp.InspectionId.Equals(inspectionId));
            List<DamagedPart> damagedParts = new List<DamagedPart>();
            if (inspection != null)
            {
                damagedParts = await RentospectContext
                                    .DamagedParts
                                    .Where(dam => dam.InspectionResultID.Equals(inspection.ID))
                                    .AsNoTracking()
                                    .ToListAsync();
                return new InspectionResultDto()
                {
                    ID = inspection.ID,
                    ApiKey = inspection.ApiKey,
                    Status = inspection.Status,
                    CaseId = inspection.CaseId,
                    InspectionId = inspection.InspectionId,
                    Vendor = inspection.Vendor,
                    Version = inspection.Version,
                    UploadStatus = inspection.UploadStatus,
                    VehicleType = inspection.VehicleType,
                    AppFormData = inspection.AppFormData,
                    GeoLocation = inspection.GeoLocation,
                    DetectedAngle = inspection.DetectedAngle,
                    DamagedParts = damagedParts.Select(dam => new DamagedPartDto
                    {
                        ID = dam.ID,
                        PartName = dam.PartName,
                        ListOfDamages = dam.ListOfDamages,
                        DamageSeverityScore = dam.DamageSeverityScore,
                        LaborOperation = dam.LaborOperation,
                        ConfidenceScore = dam.ConfidenceScore,
                        PaintLaborUnits = dam.PaintLaborUnits,
                        RemovalRefitUnits = dam.RemovalRefitUnits,
                        LaborRepairUnits = dam.LaborRepairUnits,
                        InspectionResultID = dam.InspectionResultID
                    }).ToArray()
                };
            }
            return new InspectionResultDto();
        }
        public async Task<(InspectionDto[] inspectionDtos,
                           InspectionResultDto[] inspectionResultDtos,
                           DamagedPartDto[] damagedPartDtos)> GetInspectionResultsAsync(int userID, int companyID)
        {
            var inspections = await RentospectContext.Inspections.Where(insp => insp.UserID == userID
                                                                                &&
                                                                                insp.CompanyID == companyID).ToListAsync();
            List<string> inspectionIds = inspections.Select(insp => insp.InspectionNumber).ToList();
            var inspectionResults = await RentospectContext.InspectionResults.Where(inspResult => inspectionIds.Contains(inspResult.InspectionId))
                                                                             .ToListAsync();
            List<Guid> inspectionResultIds = inspectionResults.Select(res => res.ID).ToList();
            var damagedParts = await RentospectContext.DamagedParts.Where(dam => inspectionResultIds.Contains(dam.InspectionResultID))
                                                                   .ToListAsync();
            InspectionDto[] inspectionDtos = inspections.Select(ins => new InspectionDto()
            {
                AgreementNumber = ins.AgreementNumber,
                CarMVA_Number = string.Empty,
                CarColor = string.Empty,
                CheckType = ins.CheckType,
                CarPlateNumber = ins.PlateNumber,
                IsPending = ins.IsPending,
                IsActive = ins.IsActive,
                InspectionNumber = ins.InspectionNumber,
                InspectionDate = ins.InspectionDate,
                ID = ins.ID,
                DriverName = ins.DriverName,
                DriverEmail = ins.DriverEmail,
                CompanyName = string.Empty,
                CompanyID = ins.CompanyID,
                IsTermsAndConditionsAgreed = ins.IsTermsAndConditionsAgreed,
                CarMake = string.Empty,
                CarModel = string.Empty,
                CarID = ins.CarID,
                PlateNumber = ins.PlateNumber,
                Status = ins.Status,
                UserID = ins.UserID,
                CaseID = ins.CaseID,
            }).ToArray();
            InspectionResultDto[] inspectionResultDtos = inspectionResults.Select(insResult => new InspectionResultDto()
            {
                ID = insResult.ID,
                GeoLocation = insResult.GeoLocation,
                DetectedAngle = insResult.DetectedAngle,
                ApiKey = insResult.ApiKey,
                AppFormData = insResult.AppFormData,
                CaseId = insResult.CaseId,
                InspectionId = insResult.InspectionId,
                PlateNumber = string.Empty,
                Status = insResult.Status,
                UploadStatus = insResult.UploadStatus,
                VehicleType = insResult.VehicleType,
                Vendor = insResult.Vendor,
                Version = insResult.Version,
            }).ToArray();
            DamagedPartDto[] damagedPartDtos = damagedParts.Select(d => new DamagedPartDto()
            {
                ConfidenceScore = d.ConfidenceScore,
                DamageSeverityScore = d.DamageSeverityScore,
                ID = d.ID,
                InspectionResultID = d.InspectionResultID,
                LaborOperation = d.LaborOperation,
                LaborRepairUnits = d.LaborRepairUnits,
                ListOfDamages = d.ListOfDamages,
                PaintLaborUnits = d.PaintLaborUnits,
                PartName = d.PartName,
                RemovalRefitUnits = d.RemovalRefitUnits,
            }).ToArray();
            return (inspectionDtos, inspectionResultDtos, damagedPartDtos);
        }
    }
}
