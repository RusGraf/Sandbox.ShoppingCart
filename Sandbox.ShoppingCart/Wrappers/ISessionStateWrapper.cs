using Sandbox.ShoppingCart.Models;
using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Wrappers
{
    public interface ISessionStateWrapper
    {
        List<CartProduct> GetShoppingCart();
        void SetShoppingCart(List<CartProduct> cart);
    }
}