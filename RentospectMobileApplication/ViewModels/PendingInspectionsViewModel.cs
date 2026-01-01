
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentospectMobileApp.DBService.Contracts;
using RentospectMobileApp.Entities;
using RentospectMobileApp.Entities.CustomEnitities;
using RentospectMobileApp.Services;
using RentospectMobileApp.Views;
using RentospectMobileApplication.Entities;
using RentospectMobileApplication.Entities.CustomEnitities;
using RentospectShared.API;
using RentospectShared.CommonEnum;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentospectMobileApp.ViewModels
{
    public partial class PendingInspectionsViewModel : ObservableObject
    {
        private readonly IInspectionTypeDBService _inspectionTypeDBService;
        private readonly IInspectionDBService inspectionDBService;
        private readonly InspectionHolderService inspectionHolderService;
        private ObservableCollection<EnumItem> inspectionTypes = new();
        public ObservableCollection<EnumItem> InspectionTypes
        {
            get
            {
                return inspectionTypes;
            }
            set
            {
                inspectionTypes = value;
                OnPropertyChanged();
            }
        }
        private EnumItem _selectedInspectionType;
        public EnumItem SelectedInspectionType
        {
            get => _selectedInspectionType;
            set
            {
                if (SetProperty(ref _selectedInspectionType, value))
                {
                    FilterInspections();
                }
            }
        }

        private DateTime _fromDate = DateTime.Today.AddDays(-7); // Default: last 7 days
        public DateTime FromDate
        {
            get => _fromDate;
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    OnPropertyChanged();
                    FilterInspections(); // Optional: re-filter list
                }
            }
        }

        private DateTime _toDate = DateTime.Today;
        public DateTime ToDate
        {
            get => _toDate;
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    OnPropertyChanged();
                    FilterInspections(); // Optional: re-filter list
                }
            }
        }

        private string searchText = string.Empty;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
                FilterInspections();
            }
        }
        public IRelayCommand ShowFromDatePickerCommand { get; }
        public IRelayCommand ShowToDatePickerCommand { get; }
        public ICommand NavigateToDetailsCommand { get; }

        public List<InspectionList> Inspections { get; set; } = new();

        private ObservableCollection<InspectionList> filteredInspections = new();
        public ObservableCollection<InspectionList> FilteredInspections
        {
            get
            {
                return filteredInspections;
            }
            set
            {
                filteredInspections = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; }

        public bool IsRefreshing { get; set; }

        public PendingInspectionsViewModel(IInspectionTypeDBService inspectionTypeDBService,
                                           IInspectionDBService inspectionDBService,
                                           InspectionHolderService inspectionHolderService,
                                           IInspectionResultApi api,
                                           SQLiteAsyncConnection db)
        {
            _inspectionTypeDBService = inspectionTypeDBService;
            this.inspectionDBService = inspectionDBService;
            this.inspectionHolderService = inspectionHolderService;
            RefreshCommand = new Command(RefreshList);
            NavigateToDetailsCommand = new Command<InspectionList>(OnNavigateToDetails);
            _api = api;
            this.db = db;
            AIRefreshCommand = new Command<InspectionList>(async (inspection) => await RefreshInspectionAsync(inspection), (InspectionList inspection) => !IsAIRefreshing);
        }
        private void FilterInspections()
        {
            List<InspectionList> filteredInspections = Inspections.Where(inspection =>
                                                                        inspection.InspectionDate >= FromDate.ToUniversalTime()
                                                                        &&
                                                                        inspection.InspectionDate <= ToDate.AddDays(1).AddSeconds(-1).ToUniversalTime()
                                                                    ).ToList();
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                filteredInspections = filteredInspections.Where(i =>
                    (i.DriverName.ToUpper().Contains(SearchText.ToUpper()))
                    ||
                    (i.InspectionNumber.ToUpper().Contains(SearchText.ToUpper())
                    ||
                    (i.PlateNumber != null && i.PlateNumber.ToUpper().Contains(SearchText.ToUpper()))
                    ||
                    (i.AgreementNumber != null && i.AgreementNumber.ToUpper().Contains(SearchText.ToUpper()))
                    )
                ).ToList();
            }
            if (SelectedInspectionType?.Value == null)
            {
                FilteredInspections = new ObservableCollection<InspectionList>(filteredInspections);
            }
            else
            {
                var selectedValue = SelectedInspectionType.Value.Value;
                FilteredInspections = new ObservableCollection<InspectionList>(filteredInspections.Where(i => i.CheckType == selectedValue));
            }
        }
        private async void OnNavigateToDetails(InspectionList inspection)
        {
            if (inspection == null)
                return;
            inspectionHolderService.Clear();
            await Shell.Current.GoToAsync(nameof(InspectionDetailsView), true, new Dictionary<string, object>
                {
                    { "Inspection", inspection } // keep as object ✅
                });
        }
        private void RefreshList()
        {
            IsRefreshing = true;
            var reversed = new ObservableCollection<InspectionList>(FilteredInspections.Reverse());
            Inspections.Clear();
            foreach (var item in reversed)
                Inspections.Add(item);
            IsRefreshing = false;
        }
        public async Task InitializeAsync()
        {
            await LoadInspectionAndInspectionTypesAsync();
        }
        private async Task LoadInspectionAndInspectionTypesAsync()
        {
            Inspections = await inspectionDBService.GetInspectionsAsync();
            FilteredInspections = new ObservableCollection<InspectionList>(Inspections);

            List<EnumItem> enumItems = new List<EnumItem>();

            enumItems.Add(new EnumItem { Name = "All Types", Value = null });

            foreach (InspectionCheckTypeEnum type in Enum.GetValues(typeof(InspectionCheckTypeEnum)))
            {
                string description = type.GetType()
                                         .GetField(type.ToString())
                                         ?.GetCustomAttribute<DescriptionAttribute>()
                                         ?.Description ?? type.ToString();

                enumItems.Add(new EnumItem
                {
                    Name = description,
                    Value = type
                });
            }

            InspectionTypes = new ObservableCollection<EnumItem>(enumItems);
            SelectedInspectionType = InspectionTypes.First(); // Default: All Types

        }

        #region AI Functionalities
        private bool _isAIRefreshing;
        public bool IsAIRefreshing
        {
            get => _isAIRefreshing;
            set
            {
                _isAIRefreshing = value;
                OnPropertyChanged();
            }
        }
        public ICommand AIRefreshCommand { get; }
        private readonly IInspectionResultApi _api;
        private readonly SQLiteAsyncConnection db;

        private async Task RefreshInspectionAsync(Inspection inspection)
        {
            try
            {
                if (IsAIRefreshing)
                    return;
                IsAIRefreshing = true;
                ((Command)AIRefreshCommand).ChangeCanExecute();

                var result = await _api.GetInspectionResultByInspectionIDAsync(inspection.InspectionNumber);
                if (result != null)
                    if (string.IsNullOrEmpty(result.ApiKey))
                        return;
                InspectionResult inspectionResult = new InspectionResult()
                {
                    ApiKey = result.ApiKey,
                    AppFormData = result.AppFormData,
                    CaseId = result.CaseId,
                    DetectedAngle = result.DetectedAngle,
                    GeoLocation = result.GeoLocation,
                    ID = result.ID,
                    InspectionId = result.InspectionId,
                    Status = result.Status,
                    UploadStatus = result.UploadStatus,
                    VehicleType = result.VehicleType,
                    Vendor = result.Vendor,
                    Version = result.Version,
                    PlateNumber = result.PlateNumber,
                };
                //InspectionResultID = dam.In sinc this field
                List<DamagedPart> damagedParts = result.DamagedParts.Select(dam => new DamagedPart()
                {
                    ConfidenceScore = dam.ConfidenceScore,
                    DamageSeverityScore = dam.DamageSeverityScore,
                    ID = dam.ID,
                    LaborOperation = dam.LaborOperation,
                    InspectionResultID = dam.InspectionResultID,
                    LaborRepairUnits = dam.LaborRepairUnits,
                    ListOfDamages = dam.ListOfDamages,
                    PaintLaborUnits = dam.PaintLaborUnits,
                    PartName = dam.PartName,
                    RemovalRefitUnits = dam.RemovalRefitUnits
                }
                ).ToList();
                inspection.Status = InspactionStatusEnum.Ready;
                await db.InsertOrReplaceAsync(inspectionResult);
                Inspection inspec = new Inspection()
                {
                    AgreementNumber = inspection.AgreementNumber,
                    CarID = inspection.CarID,
                    CaseID = inspection.CaseID,
                    ID = inspection.ID,
                    CheckType = inspection.CheckType,
                    CompanyID = inspection.CompanyID,
                    CreatedAt = inspection.CreatedAt,
                    CreatedBy = inspection.CreatedBy,
                    DriverEmail = inspection.DriverEmail,
                    DriverName = inspection.DriverName,
                    InspectionDate = inspection.InspectionDate,
                    InspectionNumber = inspection.InspectionNumber,
                    InspectionTypeID = inspection.InspectionTypeID,
                    IsActive = inspection.IsActive,
                    IsPending = inspection.IsPending,
                    PlateNumber = inspectionResult.PlateNumber,
                    IsTermsAndConditionsAgreed = inspection.IsTermsAndConditionsAgreed,
                    SignatureBase64 = inspection.SignatureBase64,
                    SignatureData = inspection.SignatureData,
                    SignaturePath = inspection.SignaturePath,
                    Status = inspection.Status,
                    UpdatedAt = inspection.UpdatedAt,
                    UpdatedBy = inspection.UpdatedBy,
                    UserID = inspection.UserID
                };
                await db.InsertOrReplaceAsync(inspec);
                await db.InsertAllAsync(damagedParts);
                Inspections = await inspectionDBService.GetInspectionsAsync();
                FilterInspections();
            }
            finally
            {
                IsAIRefreshing = false;
                ((Command)AIRefreshCommand).ChangeCanExecute();
            }
        }
        #endregion


    }
}
