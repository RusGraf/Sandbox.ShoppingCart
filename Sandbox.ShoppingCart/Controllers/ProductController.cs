using Sandbox.ShoppingCart.Repositories;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public ActionResult Overview()
        {
            var model = _productRepository.GetProducts();

            return View ("Overview", model);
        }
    }
}


