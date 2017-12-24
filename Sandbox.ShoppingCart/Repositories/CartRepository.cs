using System.Collections.Generic;
using System.Web;
using Sandbox.ShoppingCart.Models;
using System.Web.SessionState;
using System.Linq;

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
        
        public void AddToCart(Product product)
        {
            List<CartProduct> cart;
            cart = (_session[shoppingCartString] == null) ? 
                new List<CartProduct>() :
                (List<CartProduct>)_session[shoppingCartString];
            
            //условие, существует ли данный продукт в корзине
            var existingProduct = cart.SingleOrDefault(x => x.ProductId == product.ProductId);
            if (existingProduct != null) 
            {
                //если существует то увеличь Qty To Order
                existingProduct.QuantityToOrder += 1;
            }
            else
            {
                // если не существует то cart.Add(cartProduct);  
                var cartProduct = new CartProduct(product);
                cart.Add(cartProduct);
            }            

            _session[shoppingCartString] = cart;
        }
    }
}