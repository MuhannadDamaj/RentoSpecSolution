using RentospectMobileApp.ViewModels;
using RentospectMobileApp.Views;

namespace RentospectMobileApp
{
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("InspectionIndexView", typeof(InspectionIndexView));
            Routing.RegisterRoute("CaptureVehicleImagesView", typeof(CaptureVehicleImagesView));
            Routing.RegisterRoute("AIProcessingView", typeof(AIProcessingView));
            Routing.RegisterRoute("InspectionDetailsView", typeof(InspectionDetailsView));
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Clear token
            await SecureStorage.SetAsync("jwt_token", string.Empty);
            // Resolve LoginView from DI
            var loginPage = App.ServiceProvider.GetRequiredService<LoginView>();
            // Navigate back
            Application.Current.MainPage = new NavigationPage(loginPage);
        }
    }
}
