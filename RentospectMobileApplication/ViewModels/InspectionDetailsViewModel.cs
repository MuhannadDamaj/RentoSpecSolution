using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using RentospectMobileApp.Configuration;
using RentospectMobileApp.DBService.Contracts;
using RentospectMobileApp.Entities;
using RentospectMobileApp.Entities.CustomEnitities;
using RentospectMobileApp.Services;
using RentospectMobileApplication.Entities;
using RentospectMobileApplication.Entities.CustomEnitities;
using RentospectShared.API;
using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentospectMobileApp.ViewModels
{
    public partial class InspectionDetailsViewModel : ObservableObject, IQueryAttributable
    {
        #region Properties
        public InspectionHolderDTO CurrentInspectionHolderDTO;
        private readonly InspectionHolderService _inspectionHolderService;
        private readonly InspectionLocalService inspectionLocalService;
        private InspectionList _inspection;
        public InspectionList Inspection
        {
            get => _inspection;
            set => SetProperty(ref _inspection, value);
        }
        private ObservableCollection<DamageList> damages = new();
        public ObservableCollection<DamageList> Damages
        {
            get
            {
                return damages;
            }
            set
            {
                damages = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<IDrawingLine> signatureLines = new ObservableCollection<IDrawingLine>();
        public ObservableCollection<IDrawingLine> SignatureLines
        {
            get { return signatureLines; }
            set
            {
                signatureLines = value;
                OnPropertyChanged();
            }
        }
        private bool isAgreeChecked;
        public bool IsAgreeChecked
        {
            get { return isAgreeChecked; }
            set
            {
                isAgreeChecked = value;
                OnPropertyChanged();
            }
        }

        private DateTime inspectionDate;
        public DateTime InspectionDate
        {
            get { return inspectionDate; }
            set
            {
                inspectionDate = value;
                OnPropertyChanged();
            }
        }
        private string driverName;
        public string DriverName
        {
            get { return driverName; }
            set
            {
                driverName = value;
                OnPropertyChanged();
            }
        }
        private string driverEmail;
        public string DriverEmail
        {
            get { return driverEmail; }
            set
            {
                driverEmail = value;
                OnPropertyChanged();
            }
        }
        private string agreementNumber;
        public string AgreementNumber
        {
            get { return agreementNumber; }
            set
            {
                agreementNumber = value;
                OnPropertyChanged();
            }
        }

        private string plateNumber;
        public string PlateNumber
        {
            get { return plateNumber; }
            set
            {
                plateNumber = value;
                OnPropertyChanged();
            }
        }
        private InspectionCheckTypeEnum inspectionCheckType;
        public InspectionCheckTypeEnum InspectionCheckType
        {
            get { return inspectionCheckType; }
            set
            {
                inspectionCheckType = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public InspectionDetailsViewModel(InspectionHolderService inspectionHolderService,
                                          InspectionLocalService inspectionLocalService)
        {
            _inspectionHolderService = inspectionHolderService;
            this.inspectionLocalService = inspectionLocalService;
            InitializeCurrentInspection();
        }
        private void InitializeCurrentInspection()
        {
            if (Inspection == null) return; // ✅ avoid null crash

            DriverName = Inspection.DriverName;
            DriverEmail = Inspection.DriverEmail;
            AgreementNumber = Inspection.AgreementNumber;
            PlateNumber = Inspection.PlateNumber;
            InspectionCheckType = Inspection.CheckType;
            InspectionDate = Inspection.InspectionDate.ToLocalTime();

            var damageList = BuildDamageList(Inspection.DamagedParts ?? new());
            Damages = new ObservableCollection<DamageList>(damageList);
        }

        private List<DamageList> BuildDamageList(List<DamagedPart> damagedParts)
        {
            if (damagedParts.Count == 0)
                return new List<DamageList>();
            List<DamageList> damageHeaders = new List<DamageList>();
            foreach (var part in damagedParts)
            {
                DamageList damageHeader = new DamageList
                {
                    ID = Guid.NewGuid(),
                    PartName = part.PartName,
                    LaborOperation = part.LaborOperation,
                    DamageDetails = FormatDamageList(part.ListOfDamages)
                };
                damageHeaders.Add(damageHeader);
            }
            return damageHeaders;
        }
        private static List<string> FormatDamageList(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<string>();

            return input
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim()) // remove extra spaces
                .Select(p =>
                    string.Join(" ", p
                        .Split('_', StringSplitOptions.RemoveEmptyEntries)
                        .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower())
                    )
                )
                .ToList();
        }

        [RelayCommand]
        private void ClearSignature()
        {
            SignatureLines.Clear();
        }
        [RelayCommand]
        private async Task SubmitAsync(DrawingView drawingView)
        {
            try
            {
                if (drawingView != null)
                {
                    if (drawingView.Lines != null && drawingView.Lines.Any())
                    {
                        var image = await drawingView.GetImageStream(200, 200); // WIDTH & HEIGHT
                        using var ms = new MemoryStream();
                        image.CopyTo(ms);
                        var bytes = ms.ToArray();

                        // 2) Convert to base64
                        string base64 = Convert.ToBase64String(bytes);

                        // 3) Save locally
                        string filePath = Path.Combine(FileSystem.AppDataDirectory, "signature.png");
                        File.WriteAllBytes(filePath, bytes);

                        // 4) Assign to your object
                        Inspection.SignaturePath = filePath;
                        Inspection.SignatureData = JsonSerializer.Serialize(drawingView.Lines); ;
                        Inspection.SignatureBase64 = base64;
                    }
                }
                Inspection inspection = new Inspection();
                inspection.ID = Inspection.ID;
                inspection.InspectionNumber = Inspection.InspectionNumber;
                inspection.CaseID = Inspection.CaseID;
                inspection.CheckType = Inspection.CheckType;
                inspection.UserID = Inspection.UserID;
                inspection.CarID = Inspection.CarID;
                inspection.InspectionDate = Inspection.InspectionDate;
                inspection.DriverName = Inspection.DriverName;
                inspection.DriverEmail = Inspection.DriverEmail;
                inspection.AgreementNumber = Inspection.AgreementNumber;
                inspection.IsPending = false;
                inspection.CompanyID = Inspection.CompanyID;
                inspection.PlateNumber = Inspection.PlateNumber;
                inspection.Status = InspactionStatusEnum.Done;
                inspection.IsTermsAndConditionsAgreed = Inspection.IsTermsAndConditionsAgreed;
                inspection.SignaturePath = Inspection.SignaturePath;
                inspection.SignatureData = Inspection.SignatureData;
                inspection.SignatureBase64 = Inspection.SignatureBase64;

                var inspectionService = new InspectionService(AppSettings.ApiBaseUrl);
                InspectionUpdateDto inspectionUpdateDto = new InspectionUpdateDto();
                inspectionUpdateDto.IsTermsAndConditionsAgreed = IsAgreeChecked;
                inspectionUpdateDto.SignatureData = null; //Inspection.SignatureData;
                inspectionUpdateDto.SignatureBase64 = Inspection.SignatureData;
                inspectionUpdateDto.Status = (int)InspactionStatusEnum.Done;
                inspectionUpdateDto.ID = Inspection.ID;
                var result = await inspectionService.FinishInspectionAsync(inspectionUpdateDto);
                if (result)
                {
                    await inspectionLocalService.FinishInspection(inspection);
                    await Shell.Current.Navigation.PopToRootAsync(false);
                    await Shell.Current.GoToAsync("//PendingPage", false);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Failed", "Error Updating Data", "OK");
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            

        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Inspection", out var param) && param is InspectionList inspection)
            {
                Inspection = inspection; // ✅ object received correctly
                InitializeCurrentInspection(); // ✅ now safe to call
            }
        }
    }
}
