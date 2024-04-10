using CommunityToolkit.Maui;
using incomeExpensTrckMAUI.Pages;
using incomeExpensTrckMAUI.ViewModels;
using incomeExpensTrckMAUI.Views;
using Microsoft.Extensions.Logging;

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

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
            mauiAppBuilder.Services.AddSingleton<IncomeViewModel>();
            mauiAppBuilder.Services.AddSingleton<ExpenseListViewModel>();
#if DEBUG
            mauiAppBuilder.Logging.AddDebug();
#endif
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IncomeView>();
            mauiAppBuilder.Services.AddSingleton<ExpenseListView>();
#if DEBUG
            mauiAppBuilder.Logging.AddDebug();
#endif
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainPage>();
            mauiAppBuilder.Services.AddSingleton<ExpensePage>();

#if DEBUG
            mauiAppBuilder.Logging.AddDebug();
#endif
            return mauiAppBuilder;
        }
    }
}