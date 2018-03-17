using Sandbox.ShoppingCart.Repositories;
using System.Net;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    /// <summary>
    /// Cart management controller
    /// </summary>
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
        public ActionResult AddToCart(string productId)
        {
            var product = _productRepository.GetProduct(productId);

            _cartRepository.AddToCart(product);

            return RedirectToAction("Overview", controllerName: "Product");
        }

        /// <summary>
        /// Returning Current Cart
        /// </summary>
        /// <returns>Cart view</returns>
        public ActionResult GetCart()
        {
            //TODO: finish code after test
            return null;
        }

        /// <summary>
        /// getting cart from the cart repository
        /// </summary>
        /// <returns>Current cart</returns>
        public PartialViewResult GetMiniCart()
        {
            return PartialView("MiniCart", _cartRepository.GetCart());
        }
    }
        
}


