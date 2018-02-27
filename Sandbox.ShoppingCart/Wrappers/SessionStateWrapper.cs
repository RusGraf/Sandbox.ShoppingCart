using Sandbox.ShoppingCart.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.SessionState;

namespace Sandbox.ShoppingCart.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class SessionStateWrapper : ISessionStateWrapper
    {
        private const string shoppingCartString = "ShoppingCart";
        private readonly HttpSessionState _session;

        public SessionStateWrapper()
        {
            _session = HttpContext.Current.Session;
        }

        public List<CartProduct> GetShoppingCart()
        {
            return _session[shoppingCartString] == null ? new List<CartProduct>() : (List<CartProduct>)_session[shoppingCartString];
        }

        public void SetShoppingCart(List<CartProduct> shoppingCart)
        {
            _session[shoppingCartString] = shoppingCart;
        }
    }
}