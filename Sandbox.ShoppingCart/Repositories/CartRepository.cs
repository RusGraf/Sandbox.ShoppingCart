using MongoDB.Driver;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.ShoppingCart.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ISessionStateWrapper _sessionStateWrapper;

        public CartRepository(ISessionStateWrapper sessionStateWrapper)
        {
            _sessionStateWrapper = sessionStateWrapper;
        }

        public void AddToCart(Product product)
        {
            List<CartProduct> cart = _sessionStateWrapper.GetShoppingCart();
            var existingProduct = cart.SingleOrDefault(x => x.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.QuantityToOrder += 1;
            }
            else
            {
                var cartProduct = new CartProduct(product);
                cart.Add(cartProduct);
            }

            _sessionStateWrapper.SetShoppingCart(cart);
        }

        public Cart GetCart()
        {
            //TODO: finish code
            var cart = new Cart {
                Products = _sessionStateWrapper.GetShoppingCart()
            };

            return cart;
        }
    }
}