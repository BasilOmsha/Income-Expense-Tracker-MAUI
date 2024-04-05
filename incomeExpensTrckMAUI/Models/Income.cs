using MongoDB.Bson;
using Realms;

namespace incomeExpensTrckMAUI.Models
{
    public partial class Income : IRealmObject // Implement the IRealmObject interface to use the Realm database.
    {
        // The ObjectId is a unique identifier for the object and is required for the object to be managed by Realm.
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("date")] // Map the property to the "date" key in the database so in code names can be different
        public DateTimeOffset Date { get; set; }

        [MapTo("amount")]
        public double Amount { get; set; }

        [MapTo("category")]
        public IList<IncomeCategory> Category { get; } = null!;

        [MapTo("account")]
        public IList<Account> Account { get; } = null!;

        [MapTo("note")]
        public string Note { get; set; }

        [MapTo("description")]
        public string Description { get; set; }
    }
}
