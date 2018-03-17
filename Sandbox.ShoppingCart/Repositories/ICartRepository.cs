using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Repositories
{
    public interface ICartRepository
    {
        void AddToCart(Product product);

        Cart GetCart();
    }
}