using MongoDB.Bson;
using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Repositories
{
    public interface IBsonMapper
    {
        BsonDocument ToBson(PurchaseOrder purchaseOrder);
    }
}