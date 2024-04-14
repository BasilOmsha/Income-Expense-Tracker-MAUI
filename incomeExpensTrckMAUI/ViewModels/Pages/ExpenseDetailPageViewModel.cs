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
        Expense editableExpense;

        [ObservableProperty]
        string id;

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task DeleteExpense(string id)
        {
            if (id == string.Empty)
            {
                await Shell.Current.DisplayAlert("Error", "Try again", "Ok");
                return;
            }

            var confirm = await Shell.Current.DisplayAlert("Warning", "Are you sure you want to delete this expense?", "Yes", "No");
            if (!confirm) return;

            expenseService.DeleteExpense(id);
            await Shell.Current.DisplayAlert("Info", expenseService.StatusMessage, "Ok");
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task UpdateExpense(string id)
        {
            if (id == string.Empty)
            {
                await Shell.Current.DisplayAlert("Error", "Try again", "Ok");
                return;
            }

            var confirm = await Shell.Current.DisplayAlert("Warning", "Are you sure you want to update this expense?", "Yes", "No");
            if (!confirm) return;
            Console.WriteLine($"The new date: {EditableExpense.Date}");
            expenseService.UpdateExpense(EditableExpense);
            await Shell.Current.DisplayAlert("Info", expenseService.StatusMessage, "Ok");
            await Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = HttpUtility.UrlDecode(query[nameof(Id)].ToString());
            Expense originalExpense = ExpenseService.GetExpense(Id);
            EditableExpense = CloneExpense(originalExpense);
          
        }

        private Expense CloneExpense(Expense originalExpense)
        {
            Console.WriteLine($"The date: {originalExpense.Date}");
            return new Expense
            {
                Id = originalExpense.Id,
                Date = originalExpense.Date,
                Amount = originalExpense.Amount,
                Category = originalExpense.Category,
                Account = originalExpense.Account,
                Location = originalExpense.Location,
                Note = originalExpense.Note,
                Description = originalExpense.Description,
            };
        }

        [RelayCommand]
        async Task RefreshFields()
        {
            //if (IsLoading)
            //    await Task.CompletedTask;
            //Debug.WriteLine("ClearFields command executed.");
            try
            {
                EditableExpense = CloneExpense(ExpenseService.GetExpense(Id));
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
