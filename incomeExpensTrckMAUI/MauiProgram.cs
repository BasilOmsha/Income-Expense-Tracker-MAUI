using CommunityToolkit.Maui;
using incomeExpensTrckMAUI.Components.ExpenseListComps;
using incomeExpensTrckMAUI.Services;
using incomeExpensTrckMAUI.ViewModels;
using incomeExpensTrckMAUI.Views;

using Microsoft.Extensions.Logging;

namespace incomeExpensTrckMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddSingleton<IncomeView>();
            builder.Services.AddSingleton<IncomeService>();
            builder.Services.AddSingleton<IncomeViewModel>();

            builder.Services.AddSingleton<ExpensePage>();
            builder.Services.AddSingleton<ExpenseListComponent>();
            builder.Services.AddSingleton<ExpensePageViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

















