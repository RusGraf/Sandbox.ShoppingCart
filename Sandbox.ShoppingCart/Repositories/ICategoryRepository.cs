using System.Collections.Generic;
using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}
