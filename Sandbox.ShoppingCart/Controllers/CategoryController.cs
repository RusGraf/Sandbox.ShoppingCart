using Sandbox.ShoppingCart.Repositories;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController() 
        {
            _categoryRepository = new CategoryRepository();
        }

        [ChildActionOnly]
        public PartialViewResult Categories()
        {
            var model = _categoryRepository.GetCategories();

            return PartialView ("Categories", model);
        }
    }
}


