
using incomeExpensTrckMAUI.Models;
using System.Collections.ObjectModel;

namespace incomeExpensTrckMAUI.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; private set; } = new();
        public ObservableCollection<Income> Incomes { get; private set; } = new();

        public MainPageViewModel()
        {
            Title = "Main Page";
            GenerateDummyExpenses();
            GenerateDummyIncomes();

        }

        private void GenerateDummyExpenses()
        {
            var expense = new Expense
            {
                Date = DateTimeOffset.Now,
                Amount = 100,
                //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
                //Account = new List<Account> { new Account { Name = "Checking" } },
                Location = "Local Supermarket",
                Note = "Weekly groceries",
                Description = "Food and supplies"
            };

            expense.Category.Add(new ExpenseCategory { Name = "Groceries" });
            expense.Account.Add(new Account { Name = "Checking" });

            Expenses.Add(expense);

        }

        private void GenerateDummyIncomes()
        {
            var income = new Income
            {
                Date = DateTimeOffset.Now,
                Amount = 100,
                //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
                //Account = new List<Account> { new Account { Name = "Checking" } },
                Note = "Monthly salary",
                Description = "Salary"
            };

            income.Category.Add(new IncomeCategory { Name = "Salary" });
            income.Account.Add(new Account { Name = "Bank Transfer" });

            Incomes.Add(income);
        }
    }
}
