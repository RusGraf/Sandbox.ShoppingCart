using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sandbox.ShoppingCart.Models;
using System.Web.SessionState;

namespace Sandbox.ShoppingCart.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly HttpSessionState _session;
        private const string shoppingCartString = "ShoppingCart";

        public CartRepository (HttpSessionState session)
        {
            _session = session;
        }

        public void AddToCart(Product product)
        {
            List<Product> cart;
            if (_session[shoppingCartString] == null)
            {
                cart = new List<Product>();
            }
            else
            {
                cart = (List<Product>)_session[shoppingCartString];
            }
            cart.Add(product);
            _session[shoppingCartString] = cart;
        }
    }
}