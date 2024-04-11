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
                Category = "Coffee_Shop",
                Account = "Card",
                Location = "Starbucks",
                Note = "Food",
                Description = "Coffee"
            };

           var expense2 = new Expense()
           {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1200.00,
                Category = "Groceries",
                Account = "Cash",
                Location = "Local Supermarket",
                Note = "Weekly groceries",
                Description = "Food and supplies"
            };

            var expense3 = new Expense()
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Category = "Appreal",
                Account = "Card",
                Location = "H&M",
                Note = "Clothes",
                Description = "Supplies"
            };

            var expense4 = new Expense()
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Category = "Appreal",
                Account = "Card",
                Location = "H&M",
                Note = "Clothes",
                Description = "Supplies"
            };

            var expense5 = new Expense()
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 1500.00,
                Category = "Appreal",
                Account = "Card",
                Location = "H&M",
                Note = "Clothes",
                Description = "Supplies"
            };


            return new List<Expense> { expense1, expense2, expense3, expense4, expense5 };
        }
    }
}
