using RentospectMobileApp.Entities;
using RentospectMobileApplication.Entities;
using RentospectShared.API;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services
{
    public class MasterSyncService
    {
        private readonly IMasterSyncApi _api;
        private readonly SQLiteAsyncConnection _db;
        public MasterSyncService(IMasterSyncApi api, SQLiteAsyncConnection db)
        {
            _api = api;
            _db = db;
        }
        public async Task SyncAllData(int userId, int companyId)
        {
            var masterData = await _api.GetMasterSyncDtoAsync(userId, companyId);

            //Get Companies
            List<Company> companies = masterData.Companies.Select(cmp => new Company()
            {
                CheckInEmailTemplate = cmp.CheckInEmailTemplate,
                CheckOutEmailTemplate = cmp.CheckOutEmailTemplate,
                CreatedAt = cmp.CreatedAt,
                CreatedBy = cmp.CreatedBy,
                CurrencyID = 0,
                DesignatedEmail = cmp.DesignatedEmail,
                ID = cmp.ID,
                IsActive = cmp.IsActive,
                Logo = cmp.Logo,
                LogoBytes = cmp.LogoBytes,
                Name = cmp.Name,
                PartialCheckOutEmailTemplate = cmp.PartialCheckOutEmailTemplate,
                TermsAndConditionsMessage = cmp.TermsAndConditionsMessage,
                UpdatedAt = cmp.UpdatedAt,
                UpdatedBy = cmp.UpdatedBy,
            }).ToList();
            //Get Users
            List<User> users = masterData.Users.Select(user => new User()
            {
                CreatedAt = user.CreatedAt,
                CreatedBy = user.CreatedBy,
                Email = user.Email,
                ID = user.ID,
                IsActive = user.IsActive,
                FullName = user.FullName,
                UpdatedAt = user.UpdatedAt,
                UpdatedBy = user.UpdatedBy,
                BranchID = user.BranchID,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
            }).ToList();
            //Get Branches
            List<Branch> branches = masterData.Branches.Select(br => new Branch()
            {
                CreatedAt = br.CreatedAt,
                CreatedBy = br.CreatedBy,
                ID = br.ID,
                IsActive = br.IsActive,
                Name = br.Name,
                UpdatedAt = br.UpdatedAt,
                UpdatedBy = br.UpdatedBy,
                CompanyID = br.CompanyID,
                Address = br.Address,
                PhoneNumber = br.PhoneNumber,
                Email = br.Email,
                Code = br.Code,
                Notes = br.Notes,
            }).ToList();
            //Get Damages
            List<Damage> damages = masterData.Damages.Select(dmg => new Damage()
            {
                CreatedAt = dmg.CreatedAt,
                CreatedBy = dmg.CreatedBy,
                ID = dmg.ID,
                IsActive = dmg.IsActive,
                UpdatedAt = dmg.UpdatedAt,
                UpdatedBy = dmg.UpdatedBy,
                ExampleOnePhoto = dmg.ExampleOnePhoto,
                ExampleTwoPhoto = dmg.ExampleTwoPhoto,
                ShortDescription = dmg.ShortDescription
            }).ToList();
            //Get CarClass
            List<CarClass> carClasses = masterData.CarClasses.Select(carClasses => new CarClass()
            {
                CreatedAt = carClasses.CreatedAt,
                CreatedBy = carClasses.CreatedBy,
                ID = carClasses.ID,
                IsActive = carClasses.IsActive,
                UpdatedAt = carClasses.UpdatedAt,
                UpdatedBy = carClasses.UpdatedBy,
                CompanyID = carClasses.CompanyID,
                Description = carClasses.Description,
                Name = carClasses.Name,
            }).ToList();
            //Get Car
            List<Car> cars = masterData.Cars.Select(car => new Car()
            {
                CreatedAt = car.CreatedAt,
                CreatedBy = car.CreatedBy,
                ID = car.ID,
                IsActive = car.IsActive,
                UpdatedAt = car.UpdatedAt,
                UpdatedBy = car.UpdatedBy,
                CarClassId = car.CarClassId,
                CarMake = car.CarMake,
                CarModel = car.CarModel,
                Color = car.Color,
                MVA_Number = car.MVA_Number,
                PlateNumber = car.PlateNumber
            }).ToList();
            //Get CarCalssDamage
            List<CarClassDamage> carClassDamages = masterData.CarClassDamages.Select(carClassDamage => new CarClassDamage()
            {
                CreatedAt = carClassDamage.CreatedAt,
                CreatedBy = carClassDamage.CreatedBy,
                ID = carClassDamage.ID,
                IsActive = carClassDamage.IsActive,
                UpdatedAt = carClassDamage.UpdatedAt,
                UpdatedBy = carClassDamage.UpdatedBy,
                DamageID = carClassDamage.DamageID,
                CarClassID = carClassDamage.CarClassID,
                Price = carClassDamage.Price,
            }).ToList();
            List<Inspection> inspections = masterData.Inspections.Select(insp => new Inspection()
            {
                AgreementNumber = insp.AgreementNumber,
                CarID = insp.CarID,
                CaseID = insp.CaseID,
                CheckType = insp.CheckType,
                CompanyID = insp.CompanyID,
                DriverEmail = insp.DriverEmail,
                DriverName = insp.DriverName,
                ID = insp.ID,
                InspectionDate = insp.InspectionDate,
                InspectionNumber = insp.InspectionNumber,
                IsActive = insp.IsActive,
                IsPending = insp.IsPending,
                IsTermsAndConditionsAgreed = insp.IsTermsAndConditionsAgreed,
                PlateNumber = insp.PlateNumber,
                Status = insp.Status,
                UserID = insp.UserID,
            }).ToList();

            List<InspectionResult> inspectionResults = masterData.InspectionResults.Select(insp => new InspectionResult()
            {
                ID = insp.ID,
                GeoLocation = insp.GeoLocation,
                ApiKey = insp.ApiKey,
                AppFormData = insp.AppFormData,
                CaseId = insp.CaseId,
                DetectedAngle = insp.DetectedAngle,
                InspectionId = insp.InspectionId,
                PlateNumber = insp.PlateNumber,
                Status = insp.Status,
                UploadStatus = insp.UploadStatus,
                VehicleType = insp.VehicleType,
                Vendor = insp.Vendor,
                Version = insp.Version
            }).ToList();

            List<DamagedPart> damagedParts = masterData.DamagedParts.Select(dam => new DamagedPart()
            {
                ConfidenceScore = dam.ConfidenceScore,
                DamageSeverityScore = dam.DamageSeverityScore,
                ID = dam.ID,
                InspectionResultID = dam.InspectionResultID,
                LaborOperation = dam.LaborOperation,
                LaborRepairUnits = dam.LaborRepairUnits,
                ListOfDamages = dam.ListOfDamages,
                PaintLaborUnits = dam.PaintLaborUnits,
                PartName = dam.PartName,
                RemovalRefitUnits = dam.RemovalRefitUnits
            }).ToList();

            // Save Companies
            await _db.DeleteAllAsync<Company>();
            await _db.InsertAllAsync(companies);
            // Save Users
            await _db.DeleteAllAsync<User>();
            await _db.InsertAllAsync(users);
            // Save Branches
            await _db.DeleteAllAsync<Branch>();
            await _db.InsertAllAsync(branches);
            //Save Damages
            await _db.DeleteAllAsync<Damage>();
            await _db.InsertAllAsync(damages);
            //Save CarClasses
            await _db.DeleteAllAsync<CarClass>();
            await _db.InsertAllAsync(carClasses);
            //Save Cars
            await _db.DeleteAllAsync<Car>();
            await _db.InsertAllAsync(cars);
            //CarClassDamage
            await _db.DeleteAllAsync<CarClassDamage>();
            await _db.InsertAllAsync(carClassDamages);
            //
            await _db.DeleteAllAsync<Inspection>();
            await _db.InsertAllAsync(inspections);
            //
            await _db.DeleteAllAsync<InspectionResult>();
            await _db.InsertAllAsync(inspectionResults);
            //
            await _db.DeleteAllAsync<DamagedPart>();
            await _db.InsertAllAsync(damagedParts);
        }
    }
}
