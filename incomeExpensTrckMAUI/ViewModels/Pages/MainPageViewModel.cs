using incomeExpensTrckMAUI.Models;
using System.Collections.ObjectModel;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; private set; } = new();
        public ObservableCollection<Income> Incomes { get; private set; } = new();

        public MainPageViewModel()
        {
            Title = "Main Page Maui";
            GenerateDummyExpenses();
            GenerateDummyIncomes();
        }

        private void GenerateDummyExpenses()
        {
            var expense = new Expense
            {
                //Date = DateTimeOffset.Now.ToString(),
                Amount = 100,
                Category = "Groceries",
                Account = "Checking",
                Location = "Local Supermarket",
                Note = "Weekly groceries",
                Description = "Food and supplies"
            };

            Expenses.Add(expense);

        }

        private void GenerateDummyIncomes()
        {
            var income = new Income
            {
                Date = DateTimeOffset.Now,
                Amount = 100,
                Category = "Salary",
                Account = "Card",
                Note = "Monthly salary",
                Description = "Salary"
            };

            Incomes.Add(income);
        }
    }
}
