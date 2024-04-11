using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using incomeExpensTrckMAUI.Views.Pages.MainPages;
using incomeExpensTrckMAUI.Views.Pages.ExpensePages;
using incomeExpensTrckMAUI.ViewModels.Pages;
using incomeExpensTrckMAUI.Services;

namespace incomeExpensTrckMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
            => MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterViewModels()
                .RegisterViews()
                .RegisterServices()

                .Build();

        /* Registering dependencies with extension methods. This all */
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
            mauiAppBuilder.Services.AddSingleton<ExpensePageViewModel>(); // Singleton means that a single instance of the service is created and shared. Meaning that the same instance is used by all consumers.
            mauiAppBuilder.Services.AddTransient<AddExpensePageViewModel>(); // Transient means that a new instance of the service is created each time it is requested.
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

















