using incomeExpensTrckMAUI.Models;
using MongoDB.Bson;

namespace incomeExpensTrckMAUI.Services
{
    public class IncomeService
    {
        public List<Income> GetIncomes()
        {
            // Create the Income objects
            var income1 = new Income
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 1, 15)),
                Amount = 1500.00,
                Category = "Salary",
                Account = "Bank Accounts",
                Note = "Monthly salary",
                Description = "January Salary"
            };

            // Create the second income object and add categories and accounts similarly
            var income2 = new Income
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Category = "Bonus",
                Account = "Bank Accounts",
                Note = "Bonus",
                Description = "Bonus"
            };

            // Repeat for additional incomes
            var income3 = new Income
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Category = "Salary",
                Account = "Bank Accounts",
                Note = "Monthly salary",
                Description = "February Salary"
            };

            // Return a list of the created Income objects
            return new List<Income> { income1, income2, income3 };
        }
    }
}
