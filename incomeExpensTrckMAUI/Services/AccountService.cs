using incomeExpensTrckMAUI.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incomeExpensTrckMAUI.Services
{
    public class AccountService
    {
        public List<Account> GetAccountService()
        {
            return new List<Account>()
            {
                new Account { Id = ObjectId.GenerateNewId(), Name = "Checking Account" },
                new Account { Id = ObjectId.GenerateNewId(), Name = "Savings Account" },
                new Account { Id = ObjectId.GenerateNewId(), Name = "Credit Card" },
                new Account { Id = ObjectId.GenerateNewId(), Name = "Cash" },
                new Account { Id = ObjectId.GenerateNewId(), Name = "Paypal" },
                new Account { Id = ObjectId.GenerateNewId(), Name = "Venmo" },
                new Account { Id = ObjectId.GenerateNewId(), Name = "Zelle" },
                new Account { Id = ObjectId.GenerateNewId(), Name = "Other" }
            };
        }
    }
}
