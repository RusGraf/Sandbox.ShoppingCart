using MongoDB.Driver;

namespace Sandbox.ShoppingCart.Clients
{
    public interface IMongoDbClient
    {
        IMongoDatabase GetShoppingCartDb();
    }
}
