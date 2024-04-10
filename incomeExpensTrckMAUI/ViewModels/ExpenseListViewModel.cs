using incomeExpensTrckMAUI.Models;
using System.Collections.ObjectModel;

namespace incomeExpensTrckMAUI.ViewModels
{
    public partial class ExpenseListViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; private set; } = new();

        public ExpenseListViewModel()
        {
            Title = "Income list";
            GenerateDummyExpenses();
        }

        private void GenerateDummyExpenses()
        {
            var expense = new Expense
            {
                Date = DateTimeOffset.Now,
                Amount = 100,
                //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
                //Account = new List<Account> { new Account { Name = "Checking" } },
                Note = "Paid with cash",
                Description = "Weekly Groceries"
            };

            expense.Category.Add(new ExpenseCategory { Name = "Groceries" });
            expense.Account.Add(new Account { Name = "Cash" });

            Expenses.Add(expense);
        }
    }
}