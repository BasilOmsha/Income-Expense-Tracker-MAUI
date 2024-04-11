using incomeExpensTrckMAUI.ViewModels.Pages;

namespace incomeExpensTrckMAUI.Views.Pages.MainPages;

public partial class MainPageView : ContentPage
{
    private readonly MainPageViewModel mainPageViewModel;

    public MainPageView(MainPageViewModel mainPageViewModel)
    {
        InitializeComponent();
        BindingContext = mainPageViewModel; // Set the binding context to MainPageViewModel
        this.mainPageViewModel = mainPageViewModel;
    }
}