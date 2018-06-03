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

            //add order to the repo
            // _orderRepository.CreateOrder();

            //redirect to get order confirmation page



            //return View("OrderDetails", _orderRepository.GetOrders());
            return RedirectToAction("", new { orderId = 123L });
            throw new NotImplementedException();
        }

    }
}