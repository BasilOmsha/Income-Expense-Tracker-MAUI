using incomeExpensTrckMAUI.ViewModels;

namespace incomeExpensTrckMAUI.Views;

public partial class ExpenseListView : ContentView
{
    private readonly ExpenseListViewModel expenseListViewModel = new();

    public ExpenseListView()
    {
        InitializeComponent();
        BindingContext = expenseListViewModel;

    }

    //public ExpenseListView(ExpenseListViewModel expenseListViewModel)
    //{
    //    InitializeComponent();
    //    BindingContext = expenseListViewModel;
    //    this.expenseListViewModel = expenseListViewModel;
    //}
}