﻿using Sandbox.ShoppingCart.Repositories;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController() 
        {
            _productRepository = new ProductRepository();
        }

        public ActionResult Overview()
        {
            var model = _productRepository.GetProducts();

            return View ("Overview", model);
        }
    }
}


