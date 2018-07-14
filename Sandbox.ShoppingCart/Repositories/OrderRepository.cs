using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Clients;
using Sandbox.ShoppingCart.Models;
using System.Linq;

namespace Sandbox.ShoppingCart.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IMongoCollection<BsonDocument> ordersCollection;
        private readonly IMapper _mapper;
        private IBsonMapper _bsonMapper;
        
        public OrderRepository(IMongoDbClient mongoDbClient, IMapper mapper, IBsonMapper bsonMapper)
        {
            var shoppingCartDb = mongoDbClient.GetShoppingCartDb();
            ordersCollection = shoppingCartDb.GetCollection<BsonDocument>("Orders");
            _mapper = mapper;
            _bsonMapper = bsonMapper;
        }


        public string CreateOrder(Cart cart)
        {
            var purchaseOrder = _mapper.Map<Cart, PurchaseOrder>(cart);
            var document = _bsonMapper.ToBson(purchaseOrder);
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
    }
}