

namespace Sandbox.ShoppingCart.Models
{
    public class CartProduct : Product
    {
        public int QuantityToOrder { get; set; } = 1;
    }
}