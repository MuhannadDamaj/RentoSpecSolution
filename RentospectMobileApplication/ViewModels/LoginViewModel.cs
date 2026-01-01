
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using RentospectMobileApp.Services;
using RentospectMobileApp.Views;
using RentospectShared.API;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentospectMobileApp.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        private bool isPasswordHidden = true;
        public bool IsPasswordHidden
        {
            get { return isPasswordHidden; }
            set
            {
                isPasswordHidden = value;
                OnPropertyChanged();
            }
        }
        private bool isPasswordShown = false;
        public bool IsPasswordShown
        {
            get { return isPasswordShown; }
            set
            {
                isPasswordShown = value;
                OnPropertyChanged();
            }
        }
        public AsyncRelayCommand LoginCommand { get; }
        public ICommand OpenForgotPasswordPopupCommand { get; }
        public ICommand TogglePasswordVisibilityCommand { get; }
        public IAuthApi AuthApi { get; }
        public MasterSyncService _syncService { get; }
        public LoginViewModel(IAuthApi authApi, MasterSyncService syncService)
        {
            LoginCommand = new AsyncRelayCommand(LoginAsync);
            AuthApi = authApi;
            _syncService = syncService;
            TogglePasswordVisibilityCommand = new RelayCommand(TogglePasswordVisibility);
            OpenForgotPasswordPopupCommand = new Command(async () => await OpenForgotPasswordPopupAsync());
        }
        private async Task OpenForgotPasswordPopupAsync()
        {
            var popup = new ChangePasswordPopup();
            await App.Current.MainPage.ShowPopupAsync(popup);
        }
        private void TogglePasswordVisibility()
        {
            IsPasswordHidden = !IsPasswordHidden;
            IsPasswordShown = !IsPasswordShown;
        }
        public async Task LoginAsync()
        {
            var dto = new LoginDto
            {
                UserName = UserName,
                Password = Password,
                IsFromMobile = true,
            };

            try
            {
                var response = await AuthApi.LoginAsync(dto);

                if (response.HasError)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Login Failed",
                        response.ErrorMessage ?? "Invalid username or password.",
                        "OK");
                    return;
                }

                int userId = response.user.ID;
                int companyId = response.user.CompanyID;

                await SecureStorage.SetAsync("jwt_token", response.user.Token);
                await SecureStorage.SetAsync("user_id", userId.ToString());
                await SecureStorage.SetAsync("company_id", companyId.ToString());

                await _syncService.SyncAllData(userId, companyId);

                // Success → Navigate
                Application.Current.MainPage = new MainShell();
            }
            catch (ApiException)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Connection Error",
                    "Could not connect to the server. Please check your internet connection.",
                    "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "An unexpected error occurred. Please try again.",
                    "OK");
            }
        }
    }
}
