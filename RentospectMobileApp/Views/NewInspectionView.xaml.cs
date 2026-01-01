using RentospectMobileApp.ViewModels;
using System.Windows.Input;

namespace RentospectMobileApp.Views
{
    public partial class NewInspectionView : ContentPage
    {
        public ICommand GoToNewInspectionCommand { get; }
        public NewInspectionView()
        {
            InitializeComponent();
            GoToNewInspectionCommand = new Command(OnGoToNewInspection);
            BindingContext = this;
        }
        private async void OnGoToNewInspection()
        {
            // Navigate to the InspectionIndexView page
            await Shell.Current.GoToAsync(nameof(InspectionIndexView));
        }
    }
}
