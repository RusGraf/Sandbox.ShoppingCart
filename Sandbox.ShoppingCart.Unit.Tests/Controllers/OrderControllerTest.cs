using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.ShoppingCart.Controllers;
using Sandbox.ShoppingCart.Repositories;
using Moq;
using Sandbox.ShoppingCart.Models;
using System.Web.Mvc;
using Sandbox.ShoppingCart.Wrappers;

namespace Sandbox.ShoppingCart.Unit.Tests.Controllers
{
    [TestClass]
    public class OrderControllerTest
    {
        private OrderController _target;

        private Mock<IOrderRepository> _orderRepositoryMock;
        private Mock<ICartRepository> _cartRepositoryMock;
        private Mock<ISessionStateWrapper> _sessionStateWrapper;

        private Cart cart;
        private string orderId;

        [TestInitialize]
        public void Setup() {
            cart = new Cart();
            orderId = "123";

            _orderRepositoryMock = new Mock<IOrderRepository>();
            _cartRepositoryMock = new Mock<ICartRepository>();
            _sessionStateWrapper = new Mock<ISessionStateWrapper>();
            _orderRepositoryMock.Setup(x => x.CreateOrder(cart)).Returns(orderId);
            _cartRepositoryMock.Setup(x => x.GetCart()).Returns(cart).Verifiable();

            _target = new OrderController(_orderRepositoryMock.Object, _cartRepositoryMock.Object, _sessionStateWrapper.Object);
        }

        [TestMethod]
        public void ShouldGetCartOnCreateOrder()
        {
            _target.CreateOrder();

            _cartRepositoryMock.Verify(x => x.GetCart(), Times.Once);
        }

        [TestMethod]
        public void ShouldCreateOrderOnCreateOrder()
        {
            _target.CreateOrder();

            _orderRepositoryMock.Verify(x => x.CreateOrder(cart));
        }

        [TestMethod]
        public void ShouldRedirectToGetOrderConfirmationOnCreateOrder()
        {
            var result = (RedirectToRouteResult)_target.CreateOrder();

            Assert.AreEqual("OrderDetails", result.RouteValues["action"]);
            Assert.AreEqual(orderId, result.RouteValues["orderId"]);
            Assert.IsNull(result.RouteValues["controller"]);
        }
    }





    //class Animal
    //{
    //    public string GetName()
    //    {
    //        return null;
    //    }
    //}

    //class Dog : Animal {
    //    public new string GetName()
    //    {
    //        return "Dog";
    //    }
    //}

    //class Cat : Animal
    //{
    //    public new string GetName()
    //    {
    //        return "Cat";
    //    }
    //}

    //class Horse : Animal
    //{
    //    public new string GetName()
    //    {
    //        return "Horse";
    //    }
    //}

    //class Example
    //{
    //    public Animal getCat()
    //    {
    //        var animal =  new Cat();
    //        genericAnimalHandler(animal);
    //        return animal;
    //    }

    //    public Animal getDog()
    //    {
    //        var animal =  new Dog();
    //        genericAnimalHandler(animal);
    //        return animal;
    //    }

    //    public Animal getHorse()
    //    {
    //        return new Horse();
    //    }

    //    public void genericAnimalHandler(Animal animal)
    //    {
    //        var name = animal.GetName();
    //        //print name
    //    }
    //}
}
