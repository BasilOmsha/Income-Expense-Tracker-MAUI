using CommunityToolkit.Mvvm.ComponentModel;
using incomeExpensTrckMAUI.Models;


namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    [QueryProperty(nameof(Expense), "Expense")]
    public partial class ExpenseDetailPageViewModel : BaseViewModel
    {

        public ExpenseDetailPageViewModel()
        {
            Title = "Exp. Detail Page";
        }

        [ObservableProperty]
        Expense expense;

    }
}
