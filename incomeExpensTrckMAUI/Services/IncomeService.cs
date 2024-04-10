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
                Note = "Monthly salary",
                Description = "January Salary"
            };

            // Add categories and accounts to the first income
            income1.Category.Add(new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Salary" });
            income1.Account.Add(new Account { Id = ObjectId.GenerateNewId(), Name = "Checking Account" });

            // Create the second income object and add categories and accounts similarly
            var income2 = new Income
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Note = "Bonus",
                Description = "Bonus"
            };
            income2.Category.Add(new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Bonus" });
            income2.Account.Add(new Account { Id = ObjectId.GenerateNewId(), Name = "Checking Account" });

            // Repeat for additional incomes
            var income3 = new Income
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Note = "Monthly salary",
                Description = "February Salary"
            };
            income3.Category.Add(new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Salary" });
            income3.Account.Add(new Account { Id = ObjectId.GenerateNewId(), Name = "Checking Account" });

            // Return a list of the created Income objects
            return new List<Income> { income1, income2, income3 };
        }
    }
}
