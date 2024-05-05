using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using incomeExpensTrckMAUI.Views.Pages.ExpensePages;
using MongoDB.Bson;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Web;

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
            Title = "Exp. Page Maui";
            //GenerateDummyExpenses();
            //AddCommand = new AsyncCommand(AddExpense);
            //GetExpenseList();
            Expenses.Clear();
            this.expenseService = expenseService;
        }
        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task NavToAndGetExpenseDetail(string id)
        {
            if (id == string.Empty) return;

            await Shell.Current.GoToAsync($"{nameof(ExpenseDetailPageView)}?Id={id}", true);
        }

        [RelayCommand]
        async Task NavToAddExpense()
        {

            var route = nameof(AddExpensePageView);
            await Shell.Current.GoToAsync(route);

        }

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
    }
}
