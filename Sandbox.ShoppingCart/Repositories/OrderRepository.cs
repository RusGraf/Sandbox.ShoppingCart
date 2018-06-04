﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Clients;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Sandbox.ShoppingCart.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IMongoCollection<BsonDocument> ordersCollection;

        private static readonly ISessionStateWrapper _sessionStateWrapper;


        public OrderRepository(IMongoDbClient mongoDbClient)
        {
            var shoppingCartDb = mongoDbClient.GetShoppingCartDb();

            ordersCollection = shoppingCartDb.GetCollection<BsonDocument>("Orders");
        }

        public void CreateOrder(Cart cart)
        {
            BsonClassMap.RegisterClassMap<Order>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.OrderId)
                        .SetIgnoreIfDefault(true)
                        .SetIdGenerator(ObjectIdGenerator.Instance);
            });

            Order order = new Order
            {
                Cart = cart
            };
            ordersCollection.InsertOne(order.ToBsonDocument());
        }

        public List<Order> GetOrders()
        {
            var result = new List<Order>();
            var documents = ordersCollection.Find(_ => true).ToList();
            foreach (var document in documents)
            {
                result.Add(BsonSerializer.Deserialize<Order>(document));
            }

            return result;
        }
        public Order GetOrder(string orderId)
        {
            var allProducts = GetOrders();
            return allProducts.Single(x => x.OrderId == orderId);
        }
    }
}