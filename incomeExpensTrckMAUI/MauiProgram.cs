using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using incomeExpensTrckMAUI.Views.Pages.MainPages;
using incomeExpensTrckMAUI.Views.Pages.ExpensePages;
using incomeExpensTrckMAUI.ViewModels.Pages;

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
                .Build();

        /* Registering dependencies with extension methods. This all */
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
            mauiAppBuilder.Services.AddSingleton<ExpensePageViewModel>();
            mauiAppBuilder.Services.AddSingleton<AddExpensePageViewModel>();
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
#if DEBUG
            mauiAppBuilder.Logging.AddDebug();
#endif
            return mauiAppBuilder;
        }
    }
}

















