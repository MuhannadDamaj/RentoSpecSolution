using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentospectMobileApp.Entities.CustomEnitities;
using RentospectMobileApp.Services;
using RentospectMobileApp.Services.Contracts;
using RentospectShared.AICallReadingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RentospectMobileApp.ViewModels
{
    public partial class AIProcessingViewModel : ObservableObject
    {
        private readonly InspectionHolderService _inspectionHolderService;
        private readonly IAIInspectionService _aiInspectionService;
        public InspectionResult InspectionData { get; private set; }

        public AIProcessingViewModel(InspectionHolderService inspectionHolderService)
        {
            _inspectionHolderService = inspectionHolderService;
            _aiInspectionService = new MockAIInspectionService();
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
        private async Task NavigateToInspectionDetailAsync()
        {
            if (!Validate())
                return;
            InspectionHolderDTO currentInspectionHolderDTO = _inspectionHolderService.GetInspection();

            var result = await _aiInspectionService.GetInspectionResultAsync();
            var damagedParts = result.PreInspection.DamagedParts;
            var licensePlateReading = result.VehicleReadings.LicensePlateReading;
            damagedParts.ForEach(part => part.InspectionID = currentInspectionHolderDTO.Inspection.ID);
            currentInspectionHolderDTO.DamagedParts = damagedParts;

            currentInspectionHolderDTO.Inspection.AgreementNumber = AgreementNumber;
            currentInspectionHolderDTO.Inspection.PlateNumber = licensePlateReading;
            currentInspectionHolderDTO.Inspection.InspectionNumber = result.InspectionId;
            currentInspectionHolderDTO.Inspection.DriverName = DriverName;
            currentInspectionHolderDTO.Inspection.DriverEmail = DriverEmail;
            _inspectionHolderService.SetInspection(currentInspectionHolderDTO);
            await Shell.Current.GoToAsync("InspectionDetailsView");
        }
    }
}
