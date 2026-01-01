using Refit;
using RentospectMobileApp.Configuration;
using RentospectMobileApp.Entities;
using RentospectMobileApp.Services.Contracts;
using RentospectMobileApp.ViewModels;
using RentospectMobileApp.Views;
using RentospectMobileApplication.Entities;
using RentospectShared.API;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services
{
    public static class DependencyRegistrar
    {
        public static MauiAppBuilder RegisterDependencies(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<PendingInspectionsViewModel>();
            builder.Services.AddTransient<CaptureVehicleImagesViewModel>();
            builder.Services.AddTransient<AIProcessingViewModel>();
            builder.Services.AddTransient<InspectionDetailsViewModel>();
            builder.Services.AddTransient<MainShell>();

            // Setup SQLite
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "rentospect.db3");
            var db = new SQLiteAsyncConnection(dbPath);

            // Create tables if not exist
            db.CreateTableAsync<Company>().Wait();
            db.CreateTableAsync<User>().Wait();
            db.CreateTableAsync<Branch>().Wait();
            db.CreateTableAsync<Damage>().Wait();
            db.CreateTableAsync<CarClass>().Wait();
            db.CreateTableAsync<Car>().Wait();
            db.CreateTableAsync<CarClassDamage>().Wait();
            db.CreateTableAsync<InspectionType>().Wait();

            db.CreateTableAsync<Inspection>().Wait();
            db.CreateTableAsync<InspectionImage>().Wait();
            db.CreateTableAsync<InspectionDamage>().Wait();
            db.CreateTableAsync<InspectionResult>().Wait();
            db.CreateTableAsync<DamagedPart>().Wait();

            // Register DB connection
            builder.Services.AddSingleton(db);

            // Services
            builder.Services.AddTransient<MasterSyncService>();
            builder.Services.AddTransient<InspectionLocalService>();
            builder.Services.AddTransient<InspectionService>();
            return builder;
        }
        public static MauiAppBuilder ConfigureRefit(this MauiAppBuilder builder)
        {
            builder.Services.AddRefitClient<IAuthApi>().ConfigureHttpClient(
                httpClient => httpClient.BaseAddress = new Uri(AppSettings.ApiBaseUrl));
            builder.Services.AddRefitClient<IMasterSyncApi>(
                sp => new RefitSettings
                {
                    AuthorizationHeaderValueGetter = async (_, __) =>
                        await SecureStorage.GetAsync("jwt_token") ?? ""
                })
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(AppSettings.ApiBaseUrl);
                });
            builder.Services.AddRefitClient<IInspectionResultApi>(
           sp => new RefitSettings
           {
               AuthorizationHeaderValueGetter = async (_, __) =>
                   await SecureStorage.GetAsync("jwt_token") ?? ""
           })
            .ConfigureHttpClient(httpClient =>
            {
                httpClient.BaseAddress = new Uri(AppSettings.ApiBaseUrl);
            });
            return builder;
        }
    }
}
