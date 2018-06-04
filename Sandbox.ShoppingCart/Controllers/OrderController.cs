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
            //get order from session
            Cart cart = _cartRepository.GetCart();

            //add order to the repo
            // _orderRepository.CreateOrder();
            _orderRepository.CreateOrder(cart);            

            //redirect to get order confirmation page
            return RedirectToAction("GetOrderConfirmationPage", new { orderId = 123L });
        }

        public ActionResult GetOrderConfirmationPage(String orderId)
        {
            Order order = _orderRepository.GetOrder(orderId);
            return View("OrderDetails", order);
        }

    }
}