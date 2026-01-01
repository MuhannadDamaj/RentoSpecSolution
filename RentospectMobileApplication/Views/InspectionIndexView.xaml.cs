using RentospectMobileApp.Entities;
using RentospectMobileApp.ViewModels;
using RentospectShared.CommonEnum;

namespace RentospectMobileApp.Views
{
    [QueryProperty(nameof(InspectionTypeString), "inspectionType")]
    public partial class InspectionIndexView : ContentPage
    {
        public string InspectionTypeString { get; set; }
        public InspectionCheckTypeEnum InspectionType { get; set; }

        public InspectionIndexView()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Enum.TryParse(InspectionTypeString, out InspectionCheckTypeEnum parsed))
            {
                InspectionType = parsed;
            }
            else
            {
                // fallback (optional)
                InspectionType = InspectionCheckTypeEnum.CheckOUT;
            }
        }
        private async void OnCustomBackClicked(object sender, EventArgs e)
        {
            // Go back to the previous page
            await Shell.Current.GoToAsync("..");
        }
        private async void GoToCaptureVehicleImagesView(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(CaptureVehicleImagesView)}?inspectionType={InspectionType}");
        }
    }
}
