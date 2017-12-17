using System.Collections.Generic;
using System.Web;
using Sandbox.ShoppingCart.Models;
using System.Web.SessionState;

namespace Sandbox.ShoppingCart.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly HttpSessionState _session;
        private const string shoppingCartString = "ShoppingCart";

        public CartRepository ()
        {
            _session = HttpContext.Current.Session;
        }

        //TODO: увеличить количество в корзине если мы добаляем существующий продукт
        public void AddToCart(CartProduct cartProduct)
        {
            List<CartProduct> cart;
            if (_session[shoppingCartString] == null)
            {
                cart = new List<CartProduct>();
            }
            else
            {
                cart = (List<CartProduct>)_session[shoppingCartString];
            }
            //условие, существует ли данный продукт в корзине
            //если существует то увеличь Qty To Order
            // если не существует то cart.Add(cartProduct);
            cart.Add(cartProduct);

            _session[shoppingCartString] = cart;
        }
    }
}