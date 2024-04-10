using incomeExpensTrckMAUI.Models;
using MongoDB.Bson;

namespace incomeExpensTrckMAUI.Services
{
    public class ExpenseService
    {
        public List<Expense> GetExpenses()
        {
            var expense1 = new Expense()
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 1, 15)),
                Amount = 1500.00,
                Location = "Starbucks",
                Note = "Food",
                Description = "Coffee"
            };
            // Add categories and accounts to the first income
            expense1.Category.Add(new ExpenseCategory { Id = ObjectId.GenerateNewId(), Name = "Coffee_Shop" });
            expense1.Account.Add(new Account { Id = ObjectId.GenerateNewId(), Name = "Card" });

           var expense2 = new Expense()
           {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Location = "Local Supermarket",
                Note = "Weekly groceries",
                Description = "Food and supplies"
            };
            // Add categories and accounts to the first income
            expense2.Category.Add(new ExpenseCategory { Id = ObjectId.GenerateNewId(), Name = "Groceries" });
            expense2.Account.Add(new Account { Id = ObjectId.GenerateNewId(), Name = "Cash" });

            var expense3 = new Expense()
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Location = "H&M",
                Note = "Clothes",
                Description = "Supplies"
            };
            // Add categories and accounts to the first income
            expense3.Category.Add(new ExpenseCategory { Id = ObjectId.GenerateNewId(), Name = "Clothes" });
            expense3.Account.Add(new Account { Id = ObjectId.GenerateNewId(), Name = "Checking" });

            return new List<Expense> { expense1, expense2, expense3 };
        }
    }
}
