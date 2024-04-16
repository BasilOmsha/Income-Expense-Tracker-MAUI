using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Helpers;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using incomeExpensTrckMAUI.Views.Pages.MapsPages;
using Mapsui.UI.Maui;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    public partial class AddExpensePageViewModel : BaseViewModel
    {
        private readonly ExpenseService expenseService;
        private readonly MapModalViewModel mapModalViewModel;

        public ObservableCollection<string> YearsList { get; private set; }
        public ObservableCollection<string> MonthsList { get; private set; }
        public ObservableCollection<string> DaysList { get; private set; }

        public AddExpensePageViewModel(ExpenseService expenseService, MapModalViewModel mapModalViewModel)
        {
            Title = "Add an Expense";

            this.expenseService = expenseService;
            this.mapModalViewModel = mapModalViewModel;
            YearsList = new ObservableCollection<string>(dateGenerator.GetYearList(1920));
            MonthsList = new ObservableCollection<string>(dateGenerator.GetYearMonths(1));
            DaysList = new ObservableCollection<string>(dateGenerator.GetMonthDays(1));

            Day = DateTime.Now.Day.ToString();
            Month = DateTime.Now.Month.ToString();
            Year = DateTime.Now.Year.ToString();
        }

        //[ObservableProperty]
        //DateTime date;

        [ObservableProperty]
        string day;

        [ObservableProperty]
        string month;

        [ObservableProperty]
        string year;

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
            if (string.IsNullOrEmpty(Day) || string.IsNullOrEmpty(Month) || string.IsNullOrEmpty(Year) || string.IsNullOrEmpty(Amount) || string.IsNullOrEmpty(Category) || string.IsNullOrEmpty(Account))
            {
                await Shell.Current.DisplayAlert("Error", "Please fill in all fields", "Ok");
                return; // return stops the execution of the method
            }

            var expense = new Expense
            {
                //Date = Date.ToString(),
                Day = Day,
                Month = Month,
                Year = Year,
                Amount = double.Parse(Amount),
                Category = Category,
                Account = Account,
                Location = Location,
                Note = Note,
                Description = Description,
            };

            expenseService.AddExpense(expense);
            await Shell.Current.DisplayAlert("Info", expenseService.StatusMessage, "Ok");
            ClearFields();
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task NavToMap()
        {
            await Shell.Current.GoToAsync(nameof(MapModalView));
        }

        [RelayCommand]
        void ClearFields()
        {
            try
            {
                //Date = DateTime.Now;
                Day = DateTime.Now.Day.ToString();
                Month = DateTime.Now.Month.ToString();
                Year = DateTime.Now.Year.ToString();
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
                IsRefreshing = false;
            }
        }
    }
}
