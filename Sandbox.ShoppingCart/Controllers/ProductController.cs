using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Overview()
        {
            var model = new List<Product>();
            model.Add(new Product
            {
                Name = "product 1",
                Description = "Description 1",
                Price = 100
            });
            model.Add(new Product
            {
                Name = "product 2",
                Description = "Description 2",
                Price = 200
            });
            return View (model);
        }
    }
}


