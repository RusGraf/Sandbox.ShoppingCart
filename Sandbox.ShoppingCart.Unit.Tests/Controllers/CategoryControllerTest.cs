using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.ShoppingCart.Controllers;
using Moq;
using Sandbox.ShoppingCart.Repositories;
using System.Collections.Generic;
using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Unit.Tests
{
    [TestClass]
    public class CategoryControllerTest
    {
        private CategoryController _target;

        private Mock<ICategoryRepository> _categoryRepositoryMock;
        private List<Category> _categories;


        [TestInitialize]
        public void Setup()
        {
            _categories = new List<Category>() {
                new Category
                {
                    CategoryName = "testCategoryName1"
                }
            };
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _categoryRepositoryMock.Setup(x => x.GetCategories()).Returns(_categories);

            _target = new CategoryController(_categoryRepositoryMock.Object);
        }

        [TestMethod]
        public void GivenCategories_WhenCategories_ThenReturnPartialViewWithCorrectName()
        {
            var actual = _target.Categories().ViewName;

            Assert.AreEqual("Categories", actual);
        }

        [TestMethod]
        public void GivenCategories_WhenCategories_ThenReturnCategoriesModel()
        {
            var actual = _target.Categories().Model;

            Assert.AreEqual(_categories, actual);
        }
    }
}
