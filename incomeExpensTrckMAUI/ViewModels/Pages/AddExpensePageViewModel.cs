namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public class AddExpensePageViewModel : BaseViewModel
    {
        string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        public AddExpensePageViewModel()
        {
            Title = "Add an Expense";
        }
    }
}
