using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using incomeExpensTrckMAUI.Views.Pages.ExpensePages;
using incomeExpensTrckMAUI.ViewModels.Pages;
using incomeExpensTrckMAUI.Services;
using incomeExpensTrckMAUI.Handlers;
using incomeExpensTrckMAUI.Views.Pages.MainPages;
using SkiaSharp.Views.Maui.Controls.Hosting;
using incomeExpensTrckMAUI.Views.Pages.MapsPages;

namespace incomeExpensTrckMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
            => MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                .UseSkiaSharp(true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterViews()
                .RegisterServices()
                .RegisterViewModels()
                .ConfigureMauiHandlers(handlers => //Fixes the issue of the RefreshView not working on Android with .net8
                {
#if __ANDROID__
                    handlers.AddHandler(typeof(RefreshView), typeof(Handlers.CustomRefreshViewHandler));
#endif
                })
                .Build();

        /* Registering dependencies with extension methods. This all */
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
            mauiAppBuilder.Services.AddSingleton<ExpensePageViewModel>(); // Singleton means that a single instance of the service is created and shared. Meaning that the same instance is used by all consumers.
            mauiAppBuilder.Services.AddSingleton<AddExpensePageViewModel>(); // Transient means that a new instance of the service is created each time it is requested.
            mauiAppBuilder.Services.AddTransient<ExpenseDetailPageViewModel>();
            mauiAppBuilder.Services.AddTransient<MapsPageViewModel>();
            mauiAppBuilder.Services.AddTransient<MapModalViewModel>();
#if DEBUG   

            mauiAppBuilder.Logging.AddDebug();
#endif
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPageView>();
            mauiAppBuilder.Services.AddSingleton<ExpensePageView>();
            mauiAppBuilder.Services.AddSingleton<AddExpensePageView>();
            mauiAppBuilder.Services.AddTransient<ExpenseDetailPageView>();
            mauiAppBuilder.Services.AddTransient<MapsPageView>();
            mauiAppBuilder.Services.AddTransient<MapModalView>();
            mauiAppBuilder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
#if DEBUG
            mauiAppBuilder.Logging.AddDebug();
#endif
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ExpenseService>();
            mauiAppBuilder.Services.AddSingleton<IncomeService>();
#if DEBUG
            mauiAppBuilder.Logging.AddDebug();
#endif
            return mauiAppBuilder;
        }
    }
}

















