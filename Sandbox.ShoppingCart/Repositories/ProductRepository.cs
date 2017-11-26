using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Clients;

namespace Sandbox.ShoppingCart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<BsonDocument> _collection;

        public ProductRepository(IMongoDbClient mongoDbClient)
        {
            var shoppingCartDb = mongoDbClient.GetShoppingCartDb();

            _collection = shoppingCartDb.GetCollection<BsonDocument>("Products");
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
