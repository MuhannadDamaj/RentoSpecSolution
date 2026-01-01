using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Refit;
using RentospectMobileApp.Services;
using RentospectShared.API;
using SQLite;
using RentospectMobileApp.DBService.Services;
using RentospectMobileApp.DBService.Contracts;
using CommunityToolkit.Maui;
using RentospectMobileApp.Services.Contracts;
using RentospectMobileApp;

namespace RentospectMobileApplication
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .RegisterDependencies()
                .ConfigureRefit()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
            builder.Services.AddSingleton<InspectionHolderService>();
            builder.Services.AddSingleton<IAIInspectionService, MockAIInspectionService>();
            // Register SQLiteAsyncConnection as a singleton
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "rentospect.db3");
            builder.Services.AddSingleton(new SQLiteAsyncConnection(dbPath));
            // Register your DB service
            builder.Services.AddTransient<IInspectionTypeDBService, InspectionTypeDBService>();
            builder.Services.AddTransient<IInspectionDBService, InspectionDBService>();
#if ANDROID
            // Remove underline for all Entries on Android
            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                if (handler.PlatformView != null)
                {
                    // Set background to transparent to remove the underline
                    handler.PlatformView.Background = new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Transparent);
                }
            });
            PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                if (handler.PlatformView != null)
                {
                    handler.PlatformView.Background = new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.Transparent);
                }
            });
#endif
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}