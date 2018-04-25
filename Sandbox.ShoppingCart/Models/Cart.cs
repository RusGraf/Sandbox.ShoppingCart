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

        public double TotalPrice
        {
            get
            {
                var totalPrice = 0.0d;
                if (Products != null)
                {
                    foreach (var product in Products)
                    {
                        totalPrice += product.Price * product.QuantityToOrder;
                    }
                }
                return totalPrice;
            }
        }
    }
}