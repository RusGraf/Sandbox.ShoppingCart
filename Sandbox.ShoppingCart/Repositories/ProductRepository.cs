using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<Product> _collection;
        public ProductRepository()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("ShoppingCart");
            _collection = db.GetCollection<Product>("Product");
        }

        public List<Product> GetProducts()
        {
            return _collection.Find(_ => true).ToList();
        }
    }
}
