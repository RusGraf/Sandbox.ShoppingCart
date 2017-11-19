using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Clients;

namespace Sandbox.ShoppingCart.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IMongoCollection<BsonDocument> _collection;        

        public CategoryRepository()
        {
            var mongoDbClient = new MongoDbClient();
            var shoppingCartDb = mongoDbClient.GetShoppingCartDb();

            _collection = shoppingCartDb.GetCollection<BsonDocument>("Categories");
        }

        public List<Category> GetCategories()
        {
            var result = new List<Category>();
            var documents =  _collection.Find(_ => true).ToList();
            foreach(var document in documents) 
            {
                result.Add(BsonSerializer.Deserialize<Category>(document));
            }

            return result;
        }
    }
}
