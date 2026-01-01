using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentospectMobileApp.Configuration;
using RentospectMobileApp.Entities.CustomEnitities;
using RentospectMobileApp.Services;
using RentospectMobileApp.Services.Contracts;
using RentospectShared.AICallReadingEntities;
using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RentospectMobileApp.ViewModels
{
    [QueryProperty(nameof(InspectionTypeString), "inspectionType")]
    public partial class AIProcessingViewModel : ObservableObject
    {
        #region Properties
        private string _inspectionTypeString;
        public string InspectionTypeString
        {
            get => _inspectionTypeString;
            set
            {
                _inspectionTypeString = value;
                OnPropertyChanged();

                InitializeInspectionType();
            }
        }
        public InspectionCheckTypeEnum InspectionType { get; set; }
        private readonly InspectionHolderService _inspectionHolderService;
        private readonly InspectionLocalService inspectionLocalService;
        public InspectionResult InspectionData { get; private set; }
        InspectionHolderDTO CurrentInspectionHolderDTO = new InspectionHolderDTO();
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
        private string validationMessage;
        public string ValidationMessage
        {
            get { return validationMessage; }
            set
            {
                validationMessage = value;
                OnPropertyChanged();
            }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }
        #endregion
        public AIProcessingViewModel(InspectionHolderService inspectionHolderService,
                                     InspectionLocalService inspectionLocalService)
        {
            _inspectionHolderService = inspectionHolderService;
            this.inspectionLocalService = inspectionLocalService;
            CurrentInspectionHolderDTO = _inspectionHolderService.GetInspection();
        }
        private void InitializeInspectionType()
        {
            if (Enum.TryParse(typeof(InspectionCheckTypeEnum), InspectionTypeString, out var enumValue))
            {
                InspectionType = (InspectionCheckTypeEnum)enumValue;
            }
            else
            {
                // Default fallback if parsing fails
                InspectionType = InspectionCheckTypeEnum.CheckOUT;
            }
        }
        private bool Validate()
        {
            ValidationMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(DriverName))
            {
                ValidationMessage = "Driver name is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(DriverEmail))
            {
                ValidationMessage = "Email is required.";
                return false;
            }

            if (!Regex.IsMatch(DriverEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ValidationMessage = "Invalid email format.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(AgreementNumber))
            {
                ValidationMessage = "Agreement number is required.";
                return false;
            }
            return true;
        }
        [RelayCommand]
        private async Task StartInspectionAsync()
        {
            if (!Validate())
                return;
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                CurrentInspectionHolderDTO.Inspection.AgreementNumber = AgreementNumber;
                CurrentInspectionHolderDTO.Inspection.DriverName = DriverName;
                CurrentInspectionHolderDTO.Inspection.DriverEmail = DriverEmail;
                CurrentInspectionHolderDTO.Inspection.CheckType = InspectionType;

                CurrentInspectionHolderDTO.Inspection.SignaturePath = string.Empty;
                CurrentInspectionHolderDTO.Inspection.SignatureData = string.Empty;
                CurrentInspectionHolderDTO.Inspection.SignatureBase64 = string.Empty;

                var inspectionResult = await inspectionLocalService.SavePrimaryInspectionAsync(CurrentInspectionHolderDTO);
                InspectionUploadDto inspectionUploadDto = PrepareInspectionForSync();
                var inspectionService = new InspectionService(AppSettings.ApiBaseUrl);
                var success = await inspectionService.UploadInspectionAsync(inspectionUploadDto);
                if (!success.Success)
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
                    var responce = await inspectionService.UploadAllImagesAsync(inspectionUploadDto.ID, uploadImages, jwtToken);
                    var json = await responce.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var result = JsonSerializer.Deserialize<BulkUploadResponse>(json, options);
                    // If result is null, fallback to option 2
                    if (result == null)
                    {
                        var json2 = await responce.Content.ReadAsStringAsync();
                        result = JsonSerializer.Deserialize<BulkUploadResponse>(json);
                    }
                    else
                    {
                        if (result.Success)
                        {
                            CurrentInspectionHolderDTO.Inspection.InspectionNumber = result.Session;
                            CurrentInspectionHolderDTO.Inspection.CaseID = result.CaseId;

                            await inspectionLocalService.UpdateInspectionAIInfoAsync(CurrentInspectionHolderDTO);
                            await Shell.Current.Navigation.PopToRootAsync(false);
                            await Shell.Current.GoToAsync("//PendingPage", false);
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Failed", result.Message, "OK");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                IsBusy = false;
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
