using incomeExpensTrckMAUI.Models;
using MongoDB.Bson;

namespace incomeExpensTrckMAUI.Services
{
    public class IncomeCatagoryService
    {
        public List<IncomeCategory> GetIncomeCatagoryService() 
        {
            return new List<IncomeCategory>()
            {
                new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Salary" },
                new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Bonus" },
                new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Interest" },
                new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Dividend" },
                new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Gift" },
                new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Rental" },
                new IncomeCategory { Id = ObjectId.GenerateNewId(), Name = "Refund" },
                new IncomeCategory { Id = ObjectId.GenerateNewId(),Name = "Other" }
            };
        }
    }
}
