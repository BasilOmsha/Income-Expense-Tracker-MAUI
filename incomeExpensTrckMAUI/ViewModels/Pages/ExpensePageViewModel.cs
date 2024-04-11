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
        //public AsyncCommand AddCommand { get; }

        // Implements dependency injection to inject the ExpenseService into the constructor.
        public ExpensePageViewModel(ExpenseService expenseService)
        {
            Title = "Exp. Page";
            //GenerateDummyExpenses();
            //AddCommand = new AsyncCommand(AddExpense);
            this.expenseService = expenseService;
        }

        [RelayCommand]
        async Task NavToAddExpense()
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

        [RelayCommand]
        async Task GetExpenseDetail(Expense expense)
        {
            if (expense == null) return;

            await Shell.Current.GoToAsync(nameof(ExpenseDetailPageView), true, new Dictionary<string, object>
            {
                {nameof(Expense), expense}
            });
        }
    }
}
