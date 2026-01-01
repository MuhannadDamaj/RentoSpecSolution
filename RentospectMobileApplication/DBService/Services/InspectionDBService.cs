using RentospectMobileApp.DBService.Contracts;
using RentospectMobileApp.Entities;
using RentospectMobileApplication.Entities;
using RentospectMobileApplication.Entities.CustomEnitities;
using RentospectShared.AICallReadingEntities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.DBService.Services
{
    public class InspectionDBService : BaseDBService, IInspectionDBService
    {
        public InspectionDBService(SQLiteAsyncConnection db) { }
        public async Task<List<InspectionList>> GetInspectionsAsync()
        {
            var userIdString = await SecureStorage.GetAsync("user_id");
            var inspections = await Db.Table<Inspection>()
                              .Where(x => x.IsActive 
                                          && 
                                          x.UserID.Equals(userIdString)
                                          &&
                                          x.Status != RentospectShared.CommonEnum.InspactionStatusEnum.Done
                                          )
                              .OrderByDescending(x => x.InspectionDate)
                              .ToListAsync();
            List<string> inspectionIds = inspections.Select(insp => insp.InspectionNumber).ToList();
            var inspectionsResults = await Db.Table<RentospectMobileApplication.Entities.InspectionResult>()
                                    .Where(ins => inspectionIds.Contains(ins.InspectionId))
                                    .ToListAsync();
            List<Guid> inspectionResultIds = inspectionsResults.Select(insResult => insResult.ID).ToList();
            List<RentospectMobileApplication.Entities.DamagedPart> damagedParts = await Db.Table<RentospectMobileApplication.Entities.DamagedPart>()
                                                                                                                                     .Where(damaged => inspectionResultIds.Contains(damaged.InspectionResultID))
                                                                                                                                     .ToListAsync();
            bool needUpdate = false;
            foreach (var inspection in inspections)
            {
                var inspectionResult = inspectionsResults.FirstOrDefault(insp => insp.InspectionId.Equals(inspection.InspectionNumber));
                if (inspectionResult != null)
                {
                    inspection.Status = RentospectShared.CommonEnum.InspactionStatusEnum.Ready;
                    needUpdate = true;
                }
            }
            if (needUpdate)
                await Db.UpdateAllAsync(inspections);
            List<InspectionList> inspectionsList = new List<InspectionList>();
            foreach (var inspection in inspections)
            {
                InspectionList inspectionList = new InspectionList();
                inspectionList.ID = inspection.ID;
                inspectionList.InspectionNumber = inspection.InspectionNumber;
                inspectionList.CaseID = inspection.CaseID;
                inspectionList.InspectionTypeID = inspection.InspectionTypeID;
                inspectionList.CheckType = inspection.CheckType;
                inspectionList.UserID = inspection.UserID;
                inspectionList.CarID = inspection.CarID;
                inspectionList.InspectionDate = inspection.InspectionDate;
                inspectionList.DriverName = inspection.DriverName;
                inspectionList.DriverEmail = inspection.DriverEmail;
                inspectionList.AgreementNumber = inspection.AgreementNumber;
                inspectionList.IsPending = inspection.IsPending;
                inspectionList.CompanyID = inspection.CompanyID;
                inspectionList.PlateNumber = inspection.PlateNumber;
                inspectionList.Status = inspection.Status;
                inspectionList.DamagedParts = new List<RentospectMobileApplication.Entities.DamagedPart>();
                var inspectionResult = inspectionsResults.FirstOrDefault(insp => insp.InspectionId.Equals(inspection.InspectionNumber));
                if (inspectionResult != null)
                    inspectionList.DamagedParts = damagedParts.Where(damage => damage.InspectionResultID.Equals(inspectionResult.ID)).ToList();
                inspectionsList.Add(inspectionList);
            }
            return inspectionsList;
        }
    }
}
