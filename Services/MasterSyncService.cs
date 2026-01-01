using RentospectShared.DTOs;

namespace RentospectWebAPI.Services
{
    public class MasterSyncService
    {
        private readonly CompanyService _companyService;
        private readonly UserService _userService;
        private readonly CarService _carService;
        private readonly CarClassService _carClassService;
        private readonly CarClassDamageService _carClassDamageService;
        private readonly DamageService _damageService;
        private readonly BranchService _branchService;
        private readonly InspectionTypeService _inspectionTypeService;
        private readonly InspectionResultService _inspectionResultService;

        public MasterSyncService(
            CompanyService companyService,
            UserService userService,
            CarService carService,
            CarClassService carClassService,
            CarClassDamageService carClassDamageService,
            DamageService damageService,
            BranchService branchService,
            InspectionResultService inspectionResultService
        )
        {
            _companyService = companyService;
            _userService = userService;
            _carService = carService;
            _carClassService = carClassService;
            _carClassDamageService = carClassDamageService;
            _damageService = damageService;
            _branchService = branchService;
            _inspectionResultService = inspectionResultService;
        }

        public async Task<MasterSyncDto> GetMasterSyncAsync(int userId, int companyId)
        {

            var inspResult = await _inspectionResultService.GetInspectionResultsAsync(userId, companyId);


            var dto = new MasterSyncDto
            {
                Companies = await _companyService.GetCompaniesAsync(),
                Users = await _userService.GetUserByIDAsync(userId),
                Cars = await _carService.GetCarsByCompanyIDAsync(companyId),
                CarClasses = await _carClassService.GetCarClassesByCompanyIDAsync(companyId),
                CarClassDamages = await _carClassDamageService.GetCarClassDamagesByCompanyIDAsync(companyId),
                Damages = await _damageService.GetDamagesAsync(),
                Branches = await _branchService.GetBranchesAsync(),
                Inspections = inspResult.inspectionDtos,
                DamagedParts = inspResult.damagedPartDtos,
                InspectionResults = inspResult.inspectionResultDtos,
            };

            return dto;
        }
    }
}
