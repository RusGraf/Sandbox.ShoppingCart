using MongoDB.Bson;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Clients;
using Sandbox.ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository _orderRepository;
        
        // GET: Order
        public ActionResult CreateOrder()
        {
            return View("OrderDetails", _orderRepository.GetOrders());
        }

    }
}