using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using System.Diagnostics;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    public partial class AddExpensePageViewModel : BaseViewModel
    {
        private readonly ExpenseService expenseService;

        public AddExpensePageViewModel(ExpenseService expenseService)
        {
            Title = "Add an Expense";
            this.expenseService = expenseService;
            Date = DateTime.Now;
        }

        [ObservableProperty]
        DateTime date;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string amount;

        [ObservableProperty]
        string category;

        [ObservableProperty]
        string account;

        [ObservableProperty]
        string location;

        [ObservableProperty]
        string note;

        [ObservableProperty]
        string description;

        [RelayCommand]
        async Task AddExpense()
        {
            if (string.IsNullOrEmpty(Amount) || string.IsNullOrEmpty(Category) || string.IsNullOrEmpty(Account))
            {
                await Shell.Current.DisplayAlert("Error", "Please fill in all fields", "Ok");
                return; // return stops the execution of the method
            }

            var expense = new Expense
            {
                Date = Date.ToString(),
                Amount = double.Parse(Amount),
                Category = Category,
                Account = Account,
                Location = Location,
                Note = Note,
                Description = Description,
            };

            expenseService.AddExpense(expense);
            await Shell.Current.DisplayAlert("Info", expenseService.StatusMessage, "Ok");
            await ClearFields();
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task ClearFields()
        {
            //if (IsLoading)
            //    await Task.CompletedTask;
            //Debug.WriteLine("ClearFields command executed.");
            try
            {
                Date = DateTime.Now;
                Amount = string.Empty;
                Category = string.Empty;
                Account = string.Empty;
                Location = string.Empty;
                Note = string.Empty;
                Description = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //IsLoading = false;
                IsRefreshing = false;
            }

            //await Task.CompletedTask;
        }
    }
}
