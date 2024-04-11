using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using incomeExpensTrckMAUI.Views.Pages.ExpensePages;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    public partial class ExpensePageViewModel : BaseViewModel
    {
        private readonly ExpenseService expenseService; // this is a field to hold the service. Meaning it is a private variable that can be accessed by all methods in this class.
        public ObservableCollection<Expense> Expenses { get; private set; } = new(); // this is a property that can be accessed by the view. It is a collection of expenses.
        public AsyncCommand AddCommand { get; }

        // Implements dependency injection to inject the ExpenseService into the constructor.
        public ExpensePageViewModel(ExpenseService expenseService)
        {
            Title = "Exp. Page";
            //GenerateDummyExpenses();
            AddCommand = new AsyncCommand(AddExpense);
            this.expenseService = expenseService;
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

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetExpenseList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Expenses.Any()) Expenses.Clear();

                var expenses = expenseService.GetExpenses();
                foreach (var expense in expenses) Expenses.Add(expense);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get expenses: {ex.Message}");
                Console.WriteLine($"Unable to get expenses: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Unable to get expenses", "Ok");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        //private void GenerateDummyExpenses()
        //{
        //    var expense = new Expense
        //    {
        //        Date = DateTimeOffset.Now,
        //        Amount = 100,
        //        //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
        //        //Account = new List<Account> { new Account { Name = "Checking" } },
        //        Note = "Paid with cash",
        //        Description = "Weekly Groceries"
        //    };

        //    expense.Category.Add(new ExpenseCategory { Name = "Groceries" });
        //    expense.Account.Add(new Account { Name = "Cash" });

        //    Expenses.Add(expense);



        //    var expense2 = new Expense
        //    {
        //        Date = DateTimeOffset.Now,
        //        Amount = 102,
        //        //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
        //        //Account = new List<Account> { new Account { Name = "Checking" } },
        //        Note = "Paid with cash2",
        //        Description = "Weekly Groceries2"
        //    };

        //    expense2.Category.Add(new ExpenseCategory { Name = "Groceries2" });
        //    expense2.Account.Add(new Account { Name = "Cash2" });

        //    Expenses.Add(expense2);


        //    var expense3 = new Expense
        //    {
        //        Date = DateTimeOffset.Now.AddDays(-1),
        //        Amount = 103,
        //        //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
        //        //Account = new List<Account> { new Account { Name = "Checking" } },
        //        Note = "Paid with cash3",
        //        Description = "Weekly Groceries3"
        //    };

        //    expense3.Category.Add(new ExpenseCategory { Name = "Groceries3" });
        //    expense3.Account.Add(new Account { Name = "Cash3" });

        //    Expenses.Add(expense3);

        //    var expense4 = new Expense
        //    {
        //        Date = DateTimeOffset.Now.AddDays(-1),
        //        Amount = 103,
        //        //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
        //        //Account = new List<Account> { new Account { Name = "Checking" } },
        //        Note = "Paid with cash4",
        //        Description = "Weekly Groceries4"
        //    };

        //    expense4.Category.Add(new ExpenseCategory { Name = "Groceries4" });
        //    expense4.Account.Add(new Account { Name = "Cash4" });

        //    Expenses.Add(expense4);

        //    var expense5 = new Expense
        //    {
        //        Date = DateTimeOffset.Now.AddDays(-1),
        //        Amount = 103,
        //        //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
        //        //Account = new List<Account> { new Account { Name = "Checking" } },
        //        Note = "Paid with cash35",
        //        Description = "Weekly Groceries5"
        //    };

        //    expense5.Category.Add(new ExpenseCategory { Name = "Groceries5" });
        //    expense5.Account.Add(new Account { Name = "Cash5" });

        //    Expenses.Add(expense5);
        //}
    }
}
