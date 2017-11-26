using Ninject.Modules;
using Sandbox.ShoppingCart.Repositories;


namespace Sandbox.ShoppingCart.IoC
{
    public class NinjectMapper : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}