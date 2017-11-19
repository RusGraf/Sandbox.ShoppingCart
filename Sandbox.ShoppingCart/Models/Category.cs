using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Sandbox.ShoppingCart.Models
{
    public class Category
    {
        [BsonId]
        public object _id { get; set; }
        public string CategoryName { get; set; }
    }
}