using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly ExpenseService expenseService;
        public ObservableCollection<Expense> Expenses { get; private set; } = new();
        public ObservableCollection<Income> Incomes { get; private set; } = new();

        public MainPageViewModel(ExpenseService expenseService)
        {
            Title = "Main Page Maui";
            this.expenseService = expenseService;
            //GenerateDummyExpenses();
            //GenerateDummyIncomes();
            ExpensesTotal();
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        double totalExpenses;

        [RelayCommand]
        void ExpensesTotal()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Expenses.Any()) Expenses.Clear();
                TotalExpenses = 0;

                var expenses = expenseService.GetExpenses();

                foreach (var expense in expenses) Expenses.Add(expense);

                foreach (var exp in Expenses) TotalExpenses += exp.Amount; 
                Debug.WriteLine($"Total Expenses: {TotalExpenses}");
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
        //        //Date = DateTimeOffset.Now.ToString(),
        //        Amount = 100,
        //        Category = "Groceries",
        //        Account = "Checking",
        //        Location = "Local Supermarket",
        //        Note = "Weekly groceries",
        //        Description = "Food and supplies"
        //    };

        //    Expenses.Add(expense);

        //}

        //private void GenerateDummyIncomes()
        //{
        //    var income = new Income
        //    {
        //        Date = DateTimeOffset.Now,
        //        Amount = 100,
        //        Category = "Salary",
        //        Account = "Card",
        //        Note = "Monthly salary",
        //        Description = "Salary"
        //    };

        //    Incomes.Add(income);
        //}
    }
}
