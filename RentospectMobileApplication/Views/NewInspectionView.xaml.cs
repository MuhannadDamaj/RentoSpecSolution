using RentospectMobileApp.ViewModels;
using RentospectShared.CommonEnum;
using System.Windows.Input;

namespace RentospectMobileApp.Views
{
    public partial class NewInspectionView : ContentPage
    {
        public ICommand GoToInInspectionCommand { get; }
        public ICommand GoToOutInspectionCommand { get; }
        public ICommand GoToPatialOutInspectionCommand { get; }
        public NewInspectionView()
        {
            InitializeComponent();
            GoToInInspectionCommand = new Command<InspectionCheckTypeEnum>(GoToInspectionIndexView);
            GoToOutInspectionCommand = new Command<InspectionCheckTypeEnum>(GoToInspectionIndexView);
            GoToPatialOutInspectionCommand = new Command<InspectionCheckTypeEnum>(GoToInspectionIndexView);
            BindingContext = this;
        }
        private async void GoToInspectionIndexView(InspectionCheckTypeEnum inspectionCheckType)
        {
            // Navigate to the InspectionIndexView page
            await Shell.Current.GoToAsync($"{nameof(InspectionIndexView)}?inspectionType={inspectionCheckType}");
        }
    }
}
