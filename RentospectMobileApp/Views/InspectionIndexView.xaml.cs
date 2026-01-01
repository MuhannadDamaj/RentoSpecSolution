using RentospectMobileApp.Entities;
using RentospectMobileApp.ViewModels;
using RentospectShared.CommonEnum;

namespace RentospectMobileApp.Views
{

    public partial class InspectionIndexView : ContentPage
    {
        public InspectionIndexView()
        {
            InitializeComponent();
        }
        private async void OnCustomBackClicked(object sender, EventArgs e)
        {
            // Go back to the previous page
            await Shell.Current.GoToAsync("..");
        }
        private async void GoToCaptureVehicleImagesView(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CaptureVehicleImagesView");
        }
    }
}
