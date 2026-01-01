using RentospectMobileApp.ViewModels;
using Microsoft.Maui.Controls;

namespace RentospectMobileApp.Views
{
    public partial class PendingInspectionsView : ContentPage
    {
        public PendingInspectionsView(PendingInspectionsViewModel viewModel)
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

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            InpectionPicker.Focus();
        }
        //private void OnPickerButtonClicked(object sender, EventArgs e)
        //{
        //    MainThread.BeginInvokeOnMainThread(() =>
        //    {
        //        InpectionPicker.Focus();
        //    });
        //}
    }
}
