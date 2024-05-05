using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Helpers;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using incomeExpensTrckMAUI.Views.Pages.MapsPages;
using Mapsui.UI.Maui;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Web;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{

    public partial class AddExpensePageViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly ExpenseService expenseService;

        public ObservableCollection<string> YearsList { get; private set; }
        public ObservableCollection<string> MonthsList { get; private set; }
        public ObservableCollection<string> DaysList { get; private set; }

        
        public AddExpensePageViewModel(ExpenseService expenseService)
        {
            Title = "Add an Expense Maui";

            this.expenseService = expenseService;
            YearsList = new ObservableCollection<string>(dateGenerator.GetYearList(1920));
            MonthsList = new ObservableCollection<string>(dateGenerator.GetYearMonths(1));
            DaysList = new ObservableCollection<string>(dateGenerator.GetMonthDays(1));

            Day = DateTime.Now.Day.ToString();
            Month = DateTime.Now.Month.ToString();
            Year = DateTime.Now.Year.ToString();
        }

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
        [NotifyPropertyChangedFor(nameof(Location))]
        string latitude;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Location))]
        string longitude;

        [ObservableProperty]
        string note;

        [ObservableProperty]
        string description;


        private void UpdateLocation()
        {
            if (!string.IsNullOrEmpty(Latitude) && !string.IsNullOrEmpty(Longitude))
            {
                Location = $"{Latitude}, {Longitude}";
            }
            else
            {
                Location = "";
            }
        }

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
                Latitude = Latitude, 
                Longitude = Longitude, 
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Debug.WriteLine($"Received Query Parameters: {string.Join(", ", query.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");

            if (query.ContainsKey(nameof(Latitude)))
                Latitude = query[nameof(Latitude)]?.ToString();

            if (query.ContainsKey(nameof(Longitude)))
                Longitude = query[nameof(Longitude)]?.ToString();
            UpdateLocation(); // Update the location field
        }
    }
}
