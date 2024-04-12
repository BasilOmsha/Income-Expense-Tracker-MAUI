using incomeExpensTrckMAUI.ViewModels.Pages;

namespace incomeExpensTrckMAUI.Views.Pages.ExpensePages;

[XamlCompilation(XamlCompilationOptions.Compile)] // used to compile XAML into intermediate language
public partial class ExpensePageView : ContentPage
{
    // it is  a private field of the type ExpensePageViewModel injected into the constructor.
    private readonly ExpensePageViewModel expensePageViewModel;

    public ExpensePageView(ExpensePageViewModel expensePageViewModel)
    {
        InitializeComponent();
        BindingContext = expensePageViewModel;
        this.expensePageViewModel = expensePageViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
      
        // call the GetExpenseListCommand method from the ViewModel
        expensePageViewModel.GetExpenseListCommand.Execute(null);

        base.OnNavigatedTo(args);
    }
}