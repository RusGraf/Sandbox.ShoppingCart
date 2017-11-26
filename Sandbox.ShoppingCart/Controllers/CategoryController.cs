using Sandbox.ShoppingCart.Repositories;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        [ChildActionOnly]
        public PartialViewResult Categories()
        {
            var model = _categoryRepository.GetCategories();

            return PartialView ("Categories", model);
        }
    }
}


