using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace incomeExpensTrckMAUI.ViewModels
{
    public partial class IncomeViewModel : BaseViewModel
    {
        private IncomeService incomeSrvice;
        public ObservableCollection<Income> Incomes { get; private set; } = new();
        
        public IncomeViewModel()
        {
            Title = "Income list";
            GenerateDummyIncomes();
        }


        private void GenerateDummyIncomes()
        {
            var income = new Income
            {
                Date = DateTimeOffset.Now,
                Amount = 100,
                //Category = new List<ExpenseCategory> { new ExpenseCategory { Name = "Groceries" } },
                //Account = new List<Account> { new Account { Name = "Checking" } },
                Note = "Monthly salary",
                Description = "Salary"
            };

            income.Category.Add(new IncomeCategory { Name = "Salary" });
            income.Account.Add(new Account { Name = "Bank Transfer" });

            Incomes.Add(income);
        }

        //public IncomeViewModel(IncomeService incomeService)
        //{
        //    Title = "Income list";
        //    this.incomeSrvice = incomeService;
        //}

        //[RelayCommand]
        //async Task GetIncomeList()
        //{
        //    if (IsLoading) return;
        //    try
        //    {
        //        IsLoading = true;
        //        if(Incomes.Any()) Incomes.Clear();

        //        var incomes = incomeSrvice.GetIncomes();
        //        foreach (var income in incomes) Incomes.Add(income);

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Unable to get incomes: {ex.Message}");
        //        Console.WriteLine($"Unable to get incomes: {ex.Message}");
        //        await Shell.Current.DisplayAlert("Error", "Unable to get incomes", "Ok");
        //    }
        //    finally
        //    {
        //        IsLoading = false;
        //    }
        //}
    }
}
