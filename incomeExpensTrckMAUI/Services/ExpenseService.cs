﻿using incomeExpensTrckMAUI.Models;
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
                Amount = 10.00,
                Category = "Culture",
                Account = "Cash",
                Location = "Starbucks",
                Note = "Food",
                Description = "Coffee"
            };

           var expense2 = new Expense()
           {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 120.00,
                Category = "Groceries",
                Account = "Card",
                Location = "Local Supermarket",
                Note = "Weekly groceries",
                Description = "Food and supplies"
            };

            var expense3 = new Expense()
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 350.00,
                Category = "Clothes",
                Account = "Card",
                Location = "H&M",
                Note = "Clothes",
                Description = "Supplies"
            };

            var expense4 = new Expense()
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 50.00,
                Category = "Health",
                Account = "Bank Accounts",
                Location = "Hospital",
                Note = "Clothes",
                Description = "Supplies"
            };

            var expense5 = new Expense()
            {
                Id = ObjectId.GenerateNewId(),
                Date = new DateTimeOffset(new DateTime(2024, 2, 15)),
                Amount = 900.00,
                Category = "Education",
                Account = "Bank Accounts",
                Location = "HAMK",
                Note = "Clothes",
                Description = "Supplies"
            };


            return new List<Expense> { expense1, expense2, expense3, expense4, expense5 };
        }
    }
}
