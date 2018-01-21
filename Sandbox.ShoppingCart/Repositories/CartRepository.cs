using System.Collections.Generic;
using System.Web;
using Sandbox.ShoppingCart.Models;
using System.Web.SessionState;
using System.Linq;
using MongoDB.Driver;

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

            _session[shoppingCartString] = cart;
        }
    }
}