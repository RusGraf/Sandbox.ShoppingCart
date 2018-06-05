using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Sandbox.ShoppingCart.Models
{
    public class PurchaseOrder
    {
        [BsonId]
        public object _id { get; set; }

        public IList<PurchaseItem> PurchaseItems { get; set; }

        //TODO: unit test
        public double TotalPrice
        {
            get
            {
                var totalPrice = 0.0d;
                if (PurchaseItems != null)
                {
                    foreach (var product in PurchaseItems)
                    {
                        totalPrice += product.Price * product.QtyOrdered;
                    }
                }
                return totalPrice;
            }
        }
    }
}