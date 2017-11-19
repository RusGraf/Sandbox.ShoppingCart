using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace Sandbox.ShoppingCart.Clients
{
    public class MongoDbClient : IMongoDbClient
    {
        public IMongoDatabase GetShoppingCartDb()
        {
            var connectionString = "mongodb://127.0.0.1:27017";
            var client = new MongoClient(connectionString);
            return client.GetDatabase("ShoppingCart");
        }
    }
}