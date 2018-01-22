using Ninject.Modules;
using Sandbox.ShoppingCart.Clients;
using Sandbox.ShoppingCart.Repositories;
using Sandbox.ShoppingCart.Wrappers;

namespace Sandbox.ShoppingCart.IoC
{
    public class NinjectMapper : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IMongoDbClient>().To<MongoDbClient>();
            Bind<ICartRepository>().To<CartRepository>();
            Bind<ISessionStateWrapper>().To<SessionStateWrapper>();
        }
    }
}