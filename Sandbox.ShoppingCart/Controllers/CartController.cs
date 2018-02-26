using Sandbox.ShoppingCart.Repositories;
using System.Net;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly ICartRepository _cartRepository;

        public CartController(IProductRepository productRepository, ICartRepository cartRepository )
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }
        /// <summary>
        /// Adding to cart product with matching productID
        /// </summary>
        /// <param name="productId">Unique primary key</param>
        /// <returns>succes code 200</returns>
        public HttpStatusCodeResult AddToCart(string productId)
        {
            var product = _productRepository.GetProduct(productId);

            _cartRepository.AddToCart(product);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
        
}


