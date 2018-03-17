using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sandbox.ShoppingCart.Controllers;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Unit.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest
    {
        private CartController _target;

        private static Product product = new Product
        {
            ProductId = "NewProductId123"
        };

        private static Cart cart = new Cart()
        {
            Products = new List<CartProduct>()
            {
                new CartProduct(new Product()
                {
                    ProductId = "Product Id"
                })
            }
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
            _cartRepositoryMock.Setup(x => x.GetCart()).Returns(cart);

            _target = new CartController(_productRepositoryMock.Object, _cartRepositoryMock.Object);
        }

        [TestMethod]
        public void GivenProductId_WhenAddToCart_ThenAddProductToCartRepository()
        {
            _target.AddToCart(product.ProductId);

            _cartRepositoryMock.Verify(x => x.AddToCart(product));
        }

        [TestMethod]
        public void GivenProductId_WhenAddToCart_ThenReturnRedirectToOverview()
        {
            var actual = (RedirectToRouteResult)_target.AddToCart(product.ProductId);            
            
            Assert.AreEqual("Overview", actual.RouteValues["action"]);
            Assert.AreEqual("Product", actual.RouteValues["controller"]);
        }
        
        [TestMethod]
        public void WhenViewCart_ThenReturnView()
        {
            var actual = _target.GetMiniCart().ViewName;

            Assert.AreEqual("MiniCart", actual);
        }

        [TestMethod]
        public void WhenViewCart_ThenReturnModel()
        {
            var actual = _target.GetMiniCart().Model;

            Assert.AreEqual(cart, actual);
        }
    }
}

