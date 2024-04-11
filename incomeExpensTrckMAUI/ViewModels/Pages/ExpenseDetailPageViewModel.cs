using CommunityToolkit.Mvvm.ComponentModel;
using incomeExpensTrckMAUI.Models;


namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    [QueryProperty(nameof(Expense), "Expense")]
    public partial class ExpenseDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        Expense expense;

    }
}
