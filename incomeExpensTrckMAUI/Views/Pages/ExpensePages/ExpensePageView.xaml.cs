using incomeExpensTrckMAUI.ViewModels.Pages;

namespace incomeExpensTrckMAUI.Views.Pages.ExpensePages;

[XamlCompilation(XamlCompilationOptions.Compile)] // used to compile XAML into intermediate language
public partial class ExpensePageView : ContentPage
{
    private readonly ExpensePageViewModel expensePageViewModel;

    //public ExpensePage()
    //{
    //    InitializeComponent();
    //}

    public ExpensePageView(ExpensePageViewModel expensePageViewModel)
    {
        InitializeComponent();
        BindingContext = expensePageViewModel;
        //this.expensePageViewModel = expensePageViewModel;
    }
}