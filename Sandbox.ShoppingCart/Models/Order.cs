using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.ShoppingCart.Models
{
    public class Order
    {
        public Cart Cart { get; set; }

        [BsonId]
        public String OrderId { get; set; }
        
    }
}