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
    public class CategoryRepositoryTest
    {
        private ICategoryRepository _target;

        [TestInitialize]
        public void Initialize()
        {
            SetupMongoCategories();
            _target = new CategoryRepository();
        }

        [TestMethod]
        public void GivenIHaveCategories_WhenGetCategories_ThenReturnCategories()
        {
            var actualCategories = _target.GetCategories();
            foreach (var category in _categories)
            {
                Assert.IsNotNull(actualCategories.SingleOrDefault(x => x.CategoryName == category.CategoryName));
            }
        }

        private void SetupMongoCategories()
        {
            BsonClassMap.RegisterClassMap<Category>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c._id)
                        .SetIgnoreIfDefault(true) //added this line
                        .SetIdGenerator(ObjectIdGenerator.Instance);
            });

            var mongoDbClient = new MongoDbClient();
            var shoppingCartDb = mongoDbClient.GetShoppingCartDb();
            var categoryCollection = shoppingCartDb.GetCollection<BsonDocument>("Categories");

            //delete all existing categories
            var categoryFilter = categoryCollection.Find(_ => true);
            categoryCollection.DeleteMany(categoryFilter.Filter);

            //insert new list of categories
            foreach (var category in _categories)
            {
                categoryCollection.InsertOne(category.ToBsonDocument());
            }
        }

        private static List<Category> _categories = new List<Category>() {
            new Category { CategoryName = "Footware" },
            new Category { CategoryName = "Shirts" },
            new Category { CategoryName = "Pants" },
            new Category { CategoryName = "Purses" },
            new Category { CategoryName = "Hats" }
        };
    }
}
