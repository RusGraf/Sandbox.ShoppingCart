using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
