using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sandbox.ShoppingCart.Models;
using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Unit.Tests
{
    [TestClass]
    public class CartyTest
    {
        private Cart _target;
        
        [TestInitialize]
        public void Initialize()
        {
            _target = new Cart();
        }

        [TestMethod]
        public void GivenCartWithNoCartItems_WhenProductCount_ThenReturnZeroCount()
        {
            var actual = _target.ProductCount;

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenCartWithCartItems_WhenProductCount_ThenReturnCombinedProductToOrderCount()
        {
            _target = new Cart()
            {
                Products = new List<CartProduct>()
                {
                   new CartProduct(new Product() { ProductId = "1" })
                   {
                       QuantityToOrder = 3
                   },
                   new CartProduct(new Product() { ProductId = "2" })
                   {
                       QuantityToOrder = 2
                   },
                   new CartProduct(new Product() { ProductId = "3" })
                   {
                       QuantityToOrder = 1
                   }
                }
            };

            var actual = _target.ProductCount;

            Assert.AreEqual(6, actual);
        }
    }
}
