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
using RentospectShared.AICallReadingEntities;
using RentospectShared.API;
using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentospectMobileApp.ViewModels
{
    [QueryProperty(nameof(Inspection), "Inspection")]
    public partial class InspectionDetailsViewModel : ObservableObject
    {
        public InspectionHolderDTO CurrentInspectionHolderDTO;
        private readonly InspectionHolderService _inspectionHolderService;
        private readonly InspectionLocalService inspectionLocalService;

        private Inspection _inspection;
        public Inspection Inspection
        {
            get => _inspection;
            set
            {
                _inspection = value;
                OnPropertyChanged();
                InitializeCurrentInspection();
            }
        }

        public ObservableCollection<DamageList> Damages { get; set; }
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

        public InspectionDetailsViewModel(InspectionHolderService inspectionHolderService,
                                          InspectionLocalService inspectionLocalService)
        {
            _inspectionHolderService = inspectionHolderService;
            this.inspectionLocalService = inspectionLocalService;
            InitializeCurrentInspection();
        }
        private void InitializeCurrentInspection()
        {
            CurrentInspectionHolderDTO = _inspectionHolderService.GetInspection();
            if (CurrentInspectionHolderDTO != null)
            {
                DriverName = CurrentInspectionHolderDTO.Inspection.DriverName;
                DriverEmail = CurrentInspectionHolderDTO.Inspection.DriverEmail;
                AgreementNumber = CurrentInspectionHolderDTO.Inspection.AgreementNumber;
                PlateNumber = CurrentInspectionHolderDTO.Inspection.PlateNumber;
                InspectionCheckType = CurrentInspectionHolderDTO.Inspection.CheckType;
                InspectionDate = CurrentInspectionHolderDTO.Inspection.InspectionDate.ToLocalTime();
                var damageList = BuildDamageList(CurrentInspectionHolderDTO.DamagedParts);
                Damages = new ObservableCollection<DamageList>(damageList);
            }
            else if (Inspection != null)
            {
                DriverName = Inspection.DriverName;
                DriverEmail = Inspection.DriverEmail;
                AgreementNumber = Inspection.AgreementNumber;
                PlateNumber = Inspection.PlateNumber;
                InspectionCheckType = Inspection.CheckType;
                InspectionDate = Inspection.InspectionDate.ToLocalTime();
                IsAgreeChecked = Inspection.IsTermsAndConditionsAgreed;
                var lines = System.Text.Json.JsonSerializer.Deserialize<List<DrawingLine>>(Inspection.SignatureData);
                SignatureLines = new ObservableCollection<IDrawingLine>(lines);
            }
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

        [RelayCommand]
        private void ClearSignature()
        {
            SignatureLines.Clear();
        }
        [RelayCommand]
        private async Task SubmitAsync(DrawingView drawingView)
        {
            if (drawingView == null)
                return;
            if (drawingView.Lines != null && drawingView.Lines.Any())
            {
                var exportSize = new Size(400, 200);
                var backgroundBrush = new SolidColorBrush(Colors.White);
                using var stream = await DrawingView.GetImageStream(
                    drawingView.Lines,
                    exportSize,
                    backgroundBrush,
                    CancellationToken.None
                );
                if (stream == null)
                    return;
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                var bytes = ms.ToArray();
                CurrentInspectionHolderDTO.Inspection.IsTermsAndConditionsAgreed = isAgreeChecked;
                CurrentInspectionHolderDTO.SignatureBytes = bytes;
                CurrentInspectionHolderDTO.SignatureLines = SignatureLines;
                //Sync To Backend The Inspection.
                var inspectionResult = await inspectionLocalService.SaveInspectionHolderAsync(CurrentInspectionHolderDTO);
                InspectionUploadDto inspectionUploadDto = PrepareInspectionForSync();
                var inspectionService = new InspectionService(AppSettings.ApiBaseUrl);
                var success = await inspectionService.UploadInspectionAsync(inspectionUploadDto);
                if(!success.Success)
                {
                    await Shell.Current.DisplayAlert("Error", "Failed to upload inspection", "OK");
                    return;
                }
                else
                {
                    //Upload All Images
                    var uploadImages = inspectionResult.Item2
                                        .Select((img, index) => new InspectionImageUploadDto
                                        {
                                            FileName = Path.GetFileName(img.PhotoPath),
                                            LocalFilePath = img.PhotoPath,
                                            OrderIndex = index
                                        })
                                        .ToList();
                    var jwtToken = await SecureStorage.GetAsync("jwt_token");
                    await inspectionService.UploadAllImagesAsync(inspectionUploadDto.ID, uploadImages, jwtToken);
                }

                await Shell.Current.DisplayAlert("Saved", "Inspection saved successfully", "OK");
                await Shell.Current.Navigation.PopToRootAsync(false);
                await Shell.Current.GoToAsync("//PendingPage", false);
            }

        }
        
        private InspectionUploadDto PrepareInspectionForSync()
        {
            InspectionUploadDto inspectionUploadDto = new InspectionUploadDto();

            inspectionUploadDto.InspectionTypeID = CurrentInspectionHolderDTO.Inspection.InspectionTypeID;
            inspectionUploadDto.InspectionDate = CurrentInspectionHolderDTO.Inspection.InspectionDate;
            inspectionUploadDto.CheckType = (int)CurrentInspectionHolderDTO.Inspection.CheckType;
            inspectionUploadDto.CarID = CurrentInspectionHolderDTO.Inspection.CarID;
            inspectionUploadDto.CompanyID = CurrentInspectionHolderDTO.Inspection.CompanyID;
            inspectionUploadDto.DriverEmail = CurrentInspectionHolderDTO.Inspection.DriverEmail;
            inspectionUploadDto.DriverName = CurrentInspectionHolderDTO.Inspection.DriverName;
            inspectionUploadDto.ID = CurrentInspectionHolderDTO.Inspection.ID;
            inspectionUploadDto.InspectionNumber = CurrentInspectionHolderDTO.Inspection.InspectionNumber;
            inspectionUploadDto.AgreementNumber = CurrentInspectionHolderDTO.Inspection.AgreementNumber;
            inspectionUploadDto.IsTermsAndConditionsAgreed = CurrentInspectionHolderDTO.Inspection.IsTermsAndConditionsAgreed;
            inspectionUploadDto.UserID = CurrentInspectionHolderDTO.Inspection.UserID;
            inspectionUploadDto.Status = (int)CurrentInspectionHolderDTO.Inspection.Status;
            inspectionUploadDto.PlateNumber = CurrentInspectionHolderDTO.Inspection.PlateNumber;
            inspectionUploadDto.SignatureBase64 = CurrentInspectionHolderDTO.Inspection.SignatureBase64;
            return inspectionUploadDto;
        }
    }
}
