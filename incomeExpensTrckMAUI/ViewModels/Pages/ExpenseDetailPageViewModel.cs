using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using MongoDB.Bson;
using System.Web;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class ExpenseDetailPageViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly ExpenseService expenseService;
        public ExpenseDetailPageViewModel(ExpenseService expenseService)
        {
            Title = "Exp. Detail Page";
            this.expenseService = expenseService;
        }

        [ObservableProperty]
        Expense expense;

        [ObservableProperty]
        string id;

        [RelayCommand]
        async Task DeleteExpense(string id)
        {
            if (id == string.Empty)
            {
                await Shell.Current.DisplayAlert("Error", "Try again", "Ok");
                return;
            }

            //var expense = Expenses.FirstOrDefault(e => e.Id == id);
            //if (expense == null)
            //{
            //    await Shell.Current.DisplayAlert("Error", "Try again", "Ok");
            //    return;
            //}

            var confirm = await Shell.Current.DisplayAlert("Warning", "Are you sure you want to delete this expense?", "Yes", "No");
            if (!confirm) return;

            expenseService.DeleteExpense(id);
            await Shell.Current.DisplayAlert("Info", expenseService.StatusMessage, "Ok");
            await Shell.Current.GoToAsync("..");

            //Expenses.Remove(expense);
            //expenseService.DeleteExpense(id);
            //await Shell.Current.DisplayAlert("Info", expenseService.StatusMessage, "Ok");
        }

        [RelayCommand]
        async Task UpdateExpense(string id)
        {
            if (id == string.Empty)
            {
                await Shell.Current.DisplayAlert("Error", "Try again", "Ok");
                return;
            }

            var expense = new Expense
            {
                Date = Expense.Date,
                Amount = Expense.Amount,
                Category = Expense.Category,
                Account = Expense.Account,
                Location = Expense.Location,
                Note = Expense.Note,
                Description = Expense.Description,
            };

            var confirm = await Shell.Current.DisplayAlert("Warning", "Are you sure you want to update this expense?", "Yes", "No");
            if (!confirm) return;

            expenseService.UpdateExpense(id, expense);
            await Shell.Current.DisplayAlert("Info", expenseService.StatusMessage, "Ok");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = HttpUtility.UrlDecode(query[nameof(Id)].ToString());
            Expense = ExpenseService.GetExpense(Id);
        }
    }
}
