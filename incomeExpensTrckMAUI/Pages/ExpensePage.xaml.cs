using incomeExpensTrckMAUI.ViewModels;

namespace incomeExpensTrckMAUI.Pages;

public partial class ExpensePage : ContentPage
{
    private readonly ExpenseListViewModel expenseListViewModel;

    //public ExpensePage()
    //{
    //	InitializeComponent();
    //}

    public ExpensePage(ExpenseListViewModel expenseListViewModel)
    {
        InitializeComponent();
        BindingContext = expenseListViewModel;
        this.expenseListViewModel = expenseListViewModel;
    }
}