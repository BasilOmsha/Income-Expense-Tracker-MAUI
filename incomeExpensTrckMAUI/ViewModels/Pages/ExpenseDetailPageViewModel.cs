using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Helpers;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.Web;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class ExpenseDetailPageViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly ExpenseService expenseService;
        public ObservableCollection<string> YearsList { get; private set; }
        public ObservableCollection<string> MonthsList { get; private set; }
        public ObservableCollection<string> DaysList { get; private set; }
        public ExpenseDetailPageViewModel(ExpenseService expenseService)
        {
            Title = "Exp. Detail Page";
            this.expenseService = expenseService;
            YearsList = new ObservableCollection<string>(dateGenerator.GetYearList(1920));
            MonthsList = new ObservableCollection<string>(dateGenerator.GetYearMonths(1));
            DaysList = new ObservableCollection<string>(dateGenerator.GetMonthDays(1));
        }

        [ObservableProperty]
        Expense editableExpense;

        [ObservableProperty]
        string id;

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        void Cancel()
        {
            Shell.Current.GoToAsync("..");
        }

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
            Console.WriteLine($"The new date: {EditableExpense.Day}");
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
            Console.WriteLine($"The day: {originalExpense.Day}");
            return new Expense
            {
                Id = originalExpense.Id,
                //Date = originalExpense.Date,
                Day = originalExpense.Day,
                Month = originalExpense.Month,
                Year = originalExpense.Year,
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
