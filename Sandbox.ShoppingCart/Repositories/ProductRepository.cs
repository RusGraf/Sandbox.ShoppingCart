using System;
using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {
        }

        public List<Product> GetProducts()
        {
            //TODO: connect to DB
            throw new NotImplementedException();
        }
    }
}
