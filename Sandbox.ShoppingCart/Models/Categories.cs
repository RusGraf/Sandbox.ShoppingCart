using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Sandbox.ShoppingCart.Models
{
    public class Categories
    {
        [BsonId]
        public object _id { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}