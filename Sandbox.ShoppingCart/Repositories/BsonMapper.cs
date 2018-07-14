using MongoDB.Bson;
using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Repositories
{
    public class BsonMapper : IBsonMapper
    {
        public BsonDocument ToBson(PurchaseOrder purchaseOrder)
        {
            return purchaseOrder.ToBsonDocument();
        }
    }
}