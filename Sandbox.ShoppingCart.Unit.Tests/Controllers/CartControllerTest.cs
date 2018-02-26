using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sandbox.ShoppingCart.Controllers;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Repositories;

namespace Sandbox.ShoppingCart.Unit.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest
    {
        private CartController _target;

        Product product = new Product
        {
            ProductId = "NewProductId123"
        };

        private Mock<IProductRepository> _productRepositoryMock;
        private Mock<ICartRepository> _cartRepositoryMock;

        [TestInitialize]
        public void Setup()
        {            
            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(x => x.GetProduct(product.ProductId)).Returns(product);

            _cartRepositoryMock = new Mock<ICartRepository>();
            _cartRepositoryMock.Setup(x => x.AddToCart(product));            

            _target = new CartController(_productRepositoryMock.Object, _cartRepositoryMock.Object);
        }

        [TestMethod]
        public void GivenProductId_WhenAddToCart_ThenReturnSuccess()
        {
            var actual = _target.AddToCart(product.ProductId);            

            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}

