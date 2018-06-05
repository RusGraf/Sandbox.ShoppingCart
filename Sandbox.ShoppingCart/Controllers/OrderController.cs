using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Repositories;
using System;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;

        public OrderController(IOrderRepository orderRepository, ICartRepository cartRepository) {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }

        public ActionResult CreateOrder()
        {
            Cart cart = _cartRepository.GetCart();
            var orderId = _orderRepository.CreateOrder(cart);
            //TODO: clear session

            return RedirectToAction("OrderDetails", new { orderId = orderId });
        }

        public ActionResult OrderDetails(String orderId)
        {
            var order = _orderRepository.GetOrder(orderId);

            return View("OrderDetails", order);
        }

    }
}