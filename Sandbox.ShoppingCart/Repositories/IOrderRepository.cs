using MongoDB.Bson;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Models;
using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();

        Order GetOrder(string orderId);

        void CreateOrder(Cart cart);
    }
}