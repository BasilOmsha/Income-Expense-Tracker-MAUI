using MongoDB.Bson;
using Realms;

namespace incomeExpensTrckMAUI.Models
{
    public partial class Expense : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("date")]
        public DateTimeOffset Date { get; set; }

        [MapTo("amount")]
        public double Amount { get; set; }

        [MapTo("category")]
        public IList<ExpenseCategory> Category { get; } = null!; // this is implementing a list of ExpenseCategory that has its own properties

        [MapTo("account")]
        public IList<Account> Account { get; } = null!;

        [MapTo("location")]
        public string Location { get; set; }

        [MapTo("note")]
        public string Note { get; set; }

        [MapTo("description")]
        public string Description { get; set; }
    }
}
