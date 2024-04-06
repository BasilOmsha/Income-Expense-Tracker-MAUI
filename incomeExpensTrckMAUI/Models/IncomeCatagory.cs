﻿using MongoDB.Bson;
using Realms;

namespace incomeExpensTrckMAUI.Models
{
    public partial class IncomeCategory : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        public string Name { get; set; }
    }
}