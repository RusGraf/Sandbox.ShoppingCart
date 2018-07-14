using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Repositories;
using Sandbox.ShoppingCart.Wrappers;
using System.Web.Mvc;

namespace Sandbox.ShoppingCart.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ISessionStateWrapper _sessionStateWrapper;

        public OrderController(IOrderRepository orderRepository, ICartRepository cartRepository, ISessionStateWrapper sessionStateWrapper) {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _sessionStateWrapper = sessionStateWrapper;
        }

        public ActionResult CreateOrder()
        {
            Cart cart = _cartRepository.GetCart();
            var orderId = _orderRepository.CreateOrder(cart);
            _sessionStateWrapper.SetShoppingCart(null);
            

            return RedirectToAction("OrderDetails", new { orderId = orderId });
        }

        public ActionResult OrderDetails(string orderId)
        {
            var order = _orderRepository.GetOrder(orderId);

            return View("OrderDetails", order);
        }
    }
}