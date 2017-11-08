using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<BsonDocument> _collection;
        public ProductRepository()
        {
            var connectionString = "mongodb://127.0.0.1:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("ShoppingCart");
            _collection = db.GetCollection<BsonDocument>("Product");
        }

        public List<Product> GetProducts()
        {
            var result = new List<Product>();
            var documents =  _collection.Find(_ => true).ToList();
            foreach(var document in documents) 
            {
                result.Add(BsonSerializer.Deserialize<Product>(document));
            }

            return result;
        }
    }
}
