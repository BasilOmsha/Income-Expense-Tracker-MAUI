using incomeExpensTrckMAUI.ViewModels.Pages;

namespace incomeExpensTrckMAUI.Views.Pages.ExpensePages;

public partial class ExpenseDetailPageView : ContentPage
{
    public ExpenseDetailPageView(ExpenseDetailPageViewModel expenseDetailPageViewModel)
	{
		InitializeComponent();
        BindingContext = expenseDetailPageViewModel;
    }
}