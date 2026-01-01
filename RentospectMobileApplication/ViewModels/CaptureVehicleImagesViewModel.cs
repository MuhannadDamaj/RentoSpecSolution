using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentospectMobileApp.Configuration;
using RentospectMobileApp.Converters;
using RentospectMobileApp.DBService.Contracts;
using RentospectMobileApp.Entities;
using RentospectMobileApp.Entities.CustomEnitities;
using RentospectMobileApp.Services;
using RentospectMobileApp.Views;
using RentospectShared.CommonEnum;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentospectMobileApp.ViewModels
{
    [QueryProperty(nameof(InspectionTypeString), "inspectionType")]
    public partial class CaptureVehicleImagesViewModel : ObservableObject
    {
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


        private readonly InspectionHolderService _inspectionHolderService;
        public ObservableCollection<ImageSource> Photos { get; } = new();
        private string photosCounter = "0/12";
        public string PhotosCounter
        {
            get { return photosCounter; }
            set
            {
                photosCounter = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusy;
        public CaptureVehicleImagesViewModel(InspectionHolderService inspectionHolderService)
        {
            _inspectionHolderService = inspectionHolderService;
        }

        [RelayCommand]
        public async Task CapturePhotoAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            try
            {
                if (Photos.Count >= 12)
                {
                    await Shell.Current.DisplayAlert("Limit Reached", "You cannot add more than 12 photos.", "OK");
                    return;
                }
                if (!await CheckAndRequestPermissionsAsync())
                    return;

                var photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo == null)
                    return;

                string localPath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using Stream source = await photo.OpenReadAsync();
                using FileStream dest = File.OpenWrite(localPath);
                await source.CopyToAsync(dest);

                Photos.Add(ImageSource.FromFile(localPath));
                PhotosCounter = $"{Photos.Count}/12";
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task PickPhotoAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                if (!await CheckAndRequestPermissionsAsync())
                    return;

                var photo = await MediaPicker.Default.PickPhotoAsync();
                if (photo == null)
                    return;

                string localPath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using Stream source = await photo.OpenReadAsync();
                using FileStream dest = File.OpenWrite(localPath);
                await source.CopyToAsync(dest);

                Photos.Add(ImageSource.FromFile(localPath));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private void ClearPhotos()
        {
            Photos.Clear();
        }

        [RelayCommand]
        private void DeletePhoto(ImageSource photo)
        {
            if (photo == null)
                return;

            if (Photos.Contains(photo))
                Photos.Remove(photo);

            PhotosCounter = $"{Photos.Count}/12";
        }
        [RelayCommand]
        private async Task ShowImageAsync(ImageSource photo)
        {
            if (photo == null)
                return;

            // Show popup
            var popup = new ImagePreviewPopup(photo);
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }
        [RelayCommand]
        private async Task GoToAIProcessingAsync()
        {
            InspectionHolderDTO currentInspectionHolderDTO = _inspectionHolderService.GetInspection();
            if (currentInspectionHolderDTO == null)
            {
                currentInspectionHolderDTO = new InspectionHolderDTO
                {
                    Inspection = new Inspection()
                    {
                        AgreementNumber = string.Empty,
                        CarID = 1,
                        CheckType = InspectionCheckTypeEnum.PartialCheckOUT,
                        DriverName = string.Empty,
                        InspectionNumber = string.Empty,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = string.Empty,
                        IsPending = true,
                        Status = InspactionStatusEnum.Pending,
                        InspectionDate = DateTime.UtcNow,
                    },
                    InspectionPhotos = Photos.ToList()
                };
                var userIdString = await SecureStorage.GetAsync("user_id");
                var companyIdString = await SecureStorage.GetAsync("company_id");
                if (int.TryParse(userIdString, out int userId) &&
                    int.TryParse(companyIdString, out int companyId))
                {
                    currentInspectionHolderDTO.Inspection.UserID = int.Parse(userIdString);
                    currentInspectionHolderDTO.Inspection.CompanyID = companyId;
                }
            }
            else
                currentInspectionHolderDTO.InspectionPhotos = Photos.ToList();
            _inspectionHolderService.SetInspection(currentInspectionHolderDTO);
            await Shell.Current.GoToAsync($"AIProcessingView?inspectionType={InspectionType}");
        }

        [RelayCommand]
        public async Task LoadTestPhotosAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                if (Photos.Count >= 12)
                {
                    await Shell.Current.DisplayAlert("Limit Reached", "You cannot add more than 12 photos.", "OK");
                    return;
                }

                // 💡 List your embedded images here:
                var testFiles = new List<string>
                        {
                            "Car1.jpg",
                            "Car2.jpg",
                            "Car3.jpg",
                            "Car4.jpg",
                            "Car5.jpg",
                            "Car6.jpg",
                            "Car7.jpg",
                            "Car8.jpg",
                            "Car9.jpg",
                            "Car10.jpg",
                            "Car11.jpg",
                            "Car12.jpg"
                        };

                foreach (var fileName in testFiles)
                {
                    if (Photos.Count >= 12)
                        break;

                    // Open file from Resources/Raw
                    using Stream stream = await FileSystem.OpenAppPackageFileAsync(fileName);

                    // Copy file to cache (simulate camera saved photo)
                    string localPath = Path.Combine(FileSystem.CacheDirectory, fileName);

                    using FileStream dest = File.Create(localPath);
                    await stream.CopyToAsync(dest);

                    // Add to UI list
                    Photos.Add(ImageSource.FromFile(localPath));
                }

                PhotosCounter = $"{Photos.Count}/12";
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private static async Task<bool> CheckAndRequestPermissionsAsync()
        {
            var cameraStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();
            var storageStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (cameraStatus != PermissionStatus.Granted)
                cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
            if (storageStatus != PermissionStatus.Granted)
                storageStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
            return cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted;
        }
    }
}
