using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sandbox.ShoppingCart.Controllers;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.ShoppingCart.Unit.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest
    {
        private CartController _target;

        private Mock<ICartRepository> _cartRepositoryMock;
        private List<CartProduct> _cart;
    }

    [TestInitialize]
    public void Setup()
    {
        _cart = new List<CartProduct>() {
             new CartProduct
                {
                    ProductId = "1"
                }
            };
        //_cartRepositoryMock = new Mock<ICartRepository>();
        //_cartRepositoryMock.Setup(x => x.GetProduct()).Returns(HttpStatusCodeResult(HttpStatusCode.OK));

        //_target = new CartController(_cartRepositoryMock.Object);
    }
    [TestMethod]
    public void GivenProductId_WhenAddToCart_ThenReturnSuccess()
    {

    }
}
