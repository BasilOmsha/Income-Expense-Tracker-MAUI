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
        public string Category { get; set; }

        [MapTo("account")]
        public string Account { get; set; }

        [MapTo("location")]
        public string Location { get; set; }

        [MapTo("note")]
        public string Note { get; set; }

        [MapTo("description")]
        public string Description { get; set; }
    }
}
