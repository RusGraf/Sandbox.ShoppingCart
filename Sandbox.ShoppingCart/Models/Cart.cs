using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Models
{
    public class Cart
    {
        public IEnumerable<CartProduct> Products { get; set; }

        public int ProductCount { get
            {
                var count = 0;
                if (Products != null)
                {
                    foreach (var product in Products)
                    {                    
                        count += product.QuantityToOrder;
                    }
                }
                return count;
            }
        }
    }
}