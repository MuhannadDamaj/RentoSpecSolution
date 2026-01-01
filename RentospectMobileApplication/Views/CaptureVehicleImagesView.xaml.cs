using RentospectMobileApp.ViewModels;
using Microsoft.Maui.Controls;

namespace RentospectMobileApp.Views
{
    public partial class CaptureVehicleImagesView : ContentPage
    {
        public CaptureVehicleImagesView(CaptureVehicleImagesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is PendingInspectionsViewModel vm)
                await vm.InitializeAsync();
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            // Go back to the previous page
            await Shell.Current.GoToAsync("..");
        }
        
    }
}
