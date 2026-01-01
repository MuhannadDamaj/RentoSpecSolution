using RentospectMobileApp.ViewModels;
using Microsoft.Maui.Controls;

namespace RentospectMobileApp.Views
{
    public partial class AIProcessingView : ContentPage
    {
        public AIProcessingView(AIProcessingViewModel viewModel)
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
            if (BindingContext is AIProcessingViewModel vm)
            {
                if (vm.IsBusy)
                    return;
            }
            await Shell.Current.GoToAsync("..");
        }
        private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            if (BindingContext is AIProcessingViewModel vm)
            {
                if (vm.IsBusy)
                    return;
            }
            await Shell.Current.GoToAsync("InspectionDetailsView");
        }
    }
}
