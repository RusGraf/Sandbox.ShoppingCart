using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Models
{
    public class Cart
    {
        public IEnumerable<CartProduct> Products { get; set; }        

        public int ProductCount { get
            {
                var count = 0;
                var totalPrice = 0.0d;
                if (Products != null)
                {
                    foreach (var product in Products)
                    {                    
                        count += product.QuantityToOrder;
                        totalPrice += product.Price;
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
                        totalPrice += product.Price;
                    }
                }
                return totalPrice;
            }
        }
    }
}