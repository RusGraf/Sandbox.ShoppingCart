using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.ShoppingCart.Controllers;
using Moq;
using Sandbox.ShoppingCart.Repositories;
using System.Collections.Generic;
using Sandbox.ShoppingCart.Models;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Unit.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        private ProductController _target;

        private Mock<IProductRepository> _productRepositoryMock;
        private List<Product> _products;

        private string categoryName = "shoes";

        [TestInitialize]
        public void Setup()
        {
            _products = new List<Product>() {
                new Product
                {
                    Name = "testProductName1"
                }
            };
            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(x => x.GetProducts()).Returns(_products);
            _productRepositoryMock.Setup(x => x.GetProducts(categoryName)).Returns(_products);
            _target = new ProductController(_productRepositoryMock.Object);
        }

        [TestMethod]
        public void GivenProducts_WhenProducts_ThenReturnViewWithCorrectName()
        {
            var actual = (ViewResult)_target.Overview();
            
            Assert.AreEqual("Overview", actual.ViewName);
        }

        [TestMethod]
        public void GivenProducts_WhenProducts_ThenReturnProductsModel()
        {
            var actual = (ViewResult)_target.Overview();

            Assert.AreEqual(_products, actual.Model);
        }

        [TestMethod]
        public void GivenProductsCategory_WhenOverviewCategory_ThenReturnView()
        {
            //arrange
            
            //act
            var actual = (ViewResult)_target.OverviewCategory(categoryName);
            //assert
            Assert.AreEqual("Overview", actual.ViewName);
        }
        
        [TestMethod]
        public void GivenCategory_WhenOverviewCategory_ThenReturnProductsModel()
        {
            var actual = (ViewResult)_target.OverviewCategory(categoryName);

            Assert.AreEqual(_products, actual.Model);
        }
    }
}
