using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.ShoppingCart.Repositories;
using Sandbox.ShoppingCart.Clients;
using MongoDB.Bson;
using System.Collections.Generic;
using Sandbox.ShoppingCart.Models;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Linq;

namespace Sandbox.ShoppingCart.Integration.Tests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IProductRepository _target;

        [TestInitialize]
        public void Initialize()
        {
            SetupMongoProducts();
            _target = new ProductRepository(new MongoDbClient());
        }

        [TestMethod]
        public void GivenIHaveProducts_WhenGetProducts_ThenReturnProducts()
        {
            var actualProducts = _target.GetProducts();
            foreach (var product in _products)
            {
                Assert.IsNotNull(actualProducts.SingleOrDefault(x => x.ProductId == product.ProductId));
            }
        }

        private void SetupMongoProducts()
        {
            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c._id)
                        .SetIgnoreIfDefault(true) //added this line
                        .SetIdGenerator(ObjectIdGenerator.Instance);
            });

            var mongoDbClient = new MongoDbClient();
            var shoppingCartDb = mongoDbClient.GetShoppingCartDb();
            var productCollection = shoppingCartDb.GetCollection<BsonDocument>("Products");

            //delete all existing categories
            var productFilter = productCollection.Find(_ => true);
            productCollection.DeleteMany(productFilter.Filter);

            //insert new list of categories
            foreach (var product in _products)
            {
                productCollection.InsertOne(product.ToBsonDocument());
            }
        }

        private static List<Product> _products = new List<Product>() {
            new Product {
                CategoryName = "Footware",
                Description = "Red Awesome Shoes",
                Name = "Carnage red",
                Price = 110.0,
                ProductId = "1",
                QtyAvailable = 57
            },
            new Product {
                CategoryName = "Footware",
                Description = "Black Awesome Shoes",
                Name = "Dark Knight",
                Price = 230.0,
                ProductId = "2",
                QtyAvailable = 12
            },new Product {
                CategoryName = "Shirts",
                Description = "Google team shirt",
                Name = "Google team",
                Price = 30.0,
                ProductId = "3",
                QtyAvailable = 22
            },
            new Product {
                CategoryName = "Shirts",
                Description = "Prisoner Shirt",
                Name = "Kaka",
                Price = 23.0,
                ProductId = "4",
                QtyAvailable = 44
            },
            new Product {
                CategoryName = "Pants",
                Description = "Everyday jeans",
                Name = "Super jeans",
                Price = 100.0,
                ProductId = "5",
                QtyAvailable = 70
            },
            new Product {
                CategoryName = "Pants",
                Description = "Formal pants",
                Name = "Black pants",
                Price = 123.0,
                ProductId = "6",
                QtyAvailable = 14
            },
        };
    }
}
