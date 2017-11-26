using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Sandbox.ShoppingCart.Models
{
    public class Product
    {
        [BsonId]
        public object _id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double QtyAvailable { get; set; }
        public string CategoryName { get; set; }
    }
}
