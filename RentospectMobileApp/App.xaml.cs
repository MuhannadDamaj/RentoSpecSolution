using RentospectMobileApp.Views;

namespace RentospectMobileApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            MainPage = DetermineMainPage(serviceProvider);
            //SetMainPageAsync();
        }
        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
        private Page DetermineMainPage(IServiceProvider serviceProvider)
        {
            // Try to get saved token
            var token = SecureStorage.GetAsync("jwt_token").GetAwaiter().GetResult();

            if (!string.IsNullOrEmpty(token))
            {
                // Token exists → go directly to MainShell
                return serviceProvider.GetRequiredService<MainShell>();
            }
            else
            {
                // No token → show Login page without flashing
                var loginPage = serviceProvider.GetRequiredService<LoginView>();
                return new NavigationPage(loginPage);
            }
        }
        private async void SetMainPageAsync()
        {
            // Try to get the saved token
            var token = await SecureStorage.GetAsync("jwt_token");

            if (!string.IsNullOrEmpty(token))
            {
                // Token exists → go directly to MainShell
                MainPage = ServiceProvider.GetRequiredService<MainShell>();
            }
            else
            {
                // No token → show Login page
                var loginPage = ServiceProvider.GetRequiredService<LoginView>();
                MainPage = new NavigationPage(loginPage);
            }
        }
    }
}