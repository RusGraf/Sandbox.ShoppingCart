using System.Collections.Generic;
using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        List<Product> GetProducts(string categoryName);
    }
}
