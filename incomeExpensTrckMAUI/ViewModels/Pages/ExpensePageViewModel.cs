using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Views;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    public partial class ExpensePageViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; private set; } = new();
        public AsyncCommand AddCommand { get; }

        public ExpensePageViewModel()
        {
            Title = "Exp. Page";
            GenerateDummyExpenses();
            AddCommand = new AsyncCommand(AddExpense);
        }

        async Task AddExpense()
        {
            /*var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of coffee");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster of coffee");
            await CoffeeService.AddCoffee(name, roaster);
            await Refresh();*/

            var route = $"{nameof(AddExpensePageView)}?Amount=200";
            await Shell.Current.GoToAsync(route);

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



            var expense2 = new Expense
            {
                Date = DateTimeOffset.Now,
                Amount = 102,
                //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
                //Account = new List<Account> { new Account { Name = "Checking" } },
                Note = "Paid with cash2",
                Description = "Weekly Groceries2"
            };

            expense2.Category.Add(new ExpenseCategory { Name = "Groceries2" });
            expense2.Account.Add(new Account { Name = "Cash2" });

            Expenses.Add(expense2);


            var expense3 = new Expense
            {
                Date = DateTimeOffset.Now.AddDays(-1),
                Amount = 103,
                //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
                //Account = new List<Account> { new Account { Name = "Checking" } },
                Note = "Paid with cash3",
                Description = "Weekly Groceries3"
            };

            expense3.Category.Add(new ExpenseCategory { Name = "Groceries3" });
            expense3.Account.Add(new Account { Name = "Cash3" });

            Expenses.Add(expense3);

            var expense4 = new Expense
            {
                Date = DateTimeOffset.Now.AddDays(-1),
                Amount = 103,
                //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
                //Account = new List<Account> { new Account { Name = "Checking" } },
                Note = "Paid with cash4",
                Description = "Weekly Groceries4"
            };

            expense4.Category.Add(new ExpenseCategory { Name = "Groceries4" });
            expense4.Account.Add(new Account { Name = "Cash4" });

            Expenses.Add(expense4);

            var expense5 = new Expense
            {
                Date = DateTimeOffset.Now.AddDays(-1),
                Amount = 103,
                //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
                //Account = new List<Account> { new Account { Name = "Checking" } },
                Note = "Paid with cash35",
                Description = "Weekly Groceries5"
            };

            expense5.Category.Add(new ExpenseCategory { Name = "Groceries5" });
            expense5.Account.Add(new Account { Name = "Cash5" });

            Expenses.Add(expense5);
        }
    }
}
