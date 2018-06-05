using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Clients;
using Sandbox.ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.ShoppingCart.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IMongoCollection<BsonDocument> ordersCollection;
        
        public OrderRepository(IMongoDbClient mongoDbClient)
        {
            var shoppingCartDb = mongoDbClient.GetShoppingCartDb();
            ordersCollection = shoppingCartDb.GetCollection<BsonDocument>("Orders");
        }

        public string CreateOrder(Cart cart)
        {
            var document = MapToOrder(cart).ToBsonDocument();
            ordersCollection.InsertOne(document);

            return document["_id"].ToString();
        }

        //TODO: unit test
        public PurchaseOrder GetOrder(string orderId)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", orderId);
            //TODO: rethink this logic, it is crap
            var document = ordersCollection.Find(_ => true).ToList().Single(x => x["_id"].ToString() == orderId);
            return BsonSerializer.Deserialize<PurchaseOrder>(document);
        }

        //TODO: move to automapper and unit test
        private PurchaseOrder MapToOrder(Cart cart)
        {
            var result = new PurchaseOrder()
            {
                PurchaseItems = new List<PurchaseItem>()
            };
            foreach (var product in cart.Products)
            {
                result.PurchaseItems.Add(new PurchaseItem
                {
                    CategoryName = product.CategoryName,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    QtyOrdered = product.QuantityToOrder
                });
            }

            return result;
        }
    }
}