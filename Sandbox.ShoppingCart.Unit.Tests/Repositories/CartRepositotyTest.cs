using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Repositories;
using Sandbox.ShoppingCart.Wrappers;
using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Unit.Tests
{
    [TestClass]
    public class CartRepositotyTest
    {
        private ICartRepository _target;
        private Mock<ISessionStateWrapper> _sessionStateWrapperMock;
        
        [TestInitialize]
        public void Initialize()
        {
            _sessionStateWrapperMock = new Mock<ISessionStateWrapper>();
            _target = new CartRepository(_sessionStateWrapperMock.Object);
            
        }
        
        [TestMethod]
        public void GivenNotExistingProductId_WhenAddToCart_ThenProductAddedToSession()
        {
            var shoppingCart = new List<CartProduct>();
            _sessionStateWrapperMock.Setup(x => x.GetShoppingCart()).Returns(shoppingCart);
            Product product = new Product
            {
                ProductId = "NotExisting123"
            };

            _target.AddToCart(product);

            shoppingCart.Add(new CartProduct(product));
            _sessionStateWrapperMock.Verify(x => x.SetShoppingCart(shoppingCart));
        }

        [TestMethod]
        public void GivenExistingProductId_WhenAddToCart_ThenExistingProductQuantityOnOrderIncreased()
        {
            Product product = new Product
            {
                ProductId = "NotExisting123"
            };
            var shoppingCart = new List<CartProduct>()
            {
                new CartProduct(product)
            };
            _sessionStateWrapperMock.Setup(x => x.GetShoppingCart()).Returns(shoppingCart);

            _target.AddToCart(product);

            shoppingCart[0].QuantityToOrder++;
            _sessionStateWrapperMock.Verify(x => x.SetShoppingCart(shoppingCart));
        }

        [TestMethod]
        public void GivenProductsInCart_WhenGetCart_ThenReturnCart()
        {
            List<CartProduct> products = new List<CartProduct>()
            {
                new CartProduct(
                    new Product
                    {
                        ProductId = "NotExisting123"
                    }
                )
            };

            var expectedCart = new Cart
            {
                Products = products
            };

            _sessionStateWrapperMock.Setup(x => x.GetShoppingCart()).Returns(products);

            var actual = _target.GetCart();

            Assert.AreEqual(expectedCart.Products, actual.Products);
        }
    }
}
