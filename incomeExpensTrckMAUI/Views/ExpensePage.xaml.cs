using incomeExpensTrckMAUI.ViewModels;

namespace incomeExpensTrckMAUI.Views;

public partial class ExpensePage : ContentPage
{
    private readonly ExpensePageViewModel expensePageViewModel;

    //public ExpensePage()
    //{
    //    InitializeComponent();
    //}

    public ExpensePage(ExpensePageViewModel expensePageViewModel)
    {
        InitializeComponent();
        BindingContext = expensePageViewModel;
        //this.expensePageViewModel = expensePageViewModel;
    }
}