using Sandbox.ShoppingCart.Models;

namespace Sandbox.ShoppingCart.Repositories
{
    public interface IOrderRepository
    {
        PurchaseOrder GetOrder(string orderId);

        string CreateOrder(Cart cart);
    }
}