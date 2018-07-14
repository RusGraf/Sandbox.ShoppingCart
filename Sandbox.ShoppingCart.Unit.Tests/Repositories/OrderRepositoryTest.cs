using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using Sandbox.ShoppingCart.Clients;
using Sandbox.ShoppingCart.Models;
using System.Threading;

namespace Sandbox.ShoppingCart.Repositories.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private IOrderRepository _target;
        private Mock<Cart> cartMock;
        private Mock<IMongoDbClient> mongoDbClientMock;
        private Mock<IMongoDatabase> mongoDatabaseMock;
        private Mock<IMapper> mapperMock;
        private Mock<IMongoCollection<BsonDocument>> orderCollectionMock;
        private Mock<IBsonMapper> bsonMapperMock;
        private BsonDocument bsonDocument;
        private PurchaseOrder purchaseOrder;
        private readonly string _expectedOrderId = "orderId123";

        [TestInitialize]
        public void Initialize()
        {
            cartMock = new Mock<Cart>();
            mongoDbClientMock = new Mock<IMongoDbClient>();
            mapperMock = new Mock<IMapper>();
            orderCollectionMock = new Mock<IMongoCollection<BsonDocument>>();
            mongoDatabaseMock = new Mock<IMongoDatabase>();
            bsonMapperMock = new Mock<IBsonMapper>();
            bsonDocument = new BsonDocument();
            purchaseOrder = new PurchaseOrder()
            {
                _id = _expectedOrderId
            };

            bsonDocument["_id"] = _expectedOrderId;
            mapperMock.Setup(x => x.Map<Cart, PurchaseOrder>(cartMock.Object)).Returns(purchaseOrder);
            bsonMapperMock.Setup(x => x.ToBson(purchaseOrder)).Returns(bsonDocument);
            mongoDbClientMock.Setup(x => x.GetShoppingCartDb()).Returns(mongoDatabaseMock.Object);
            mongoDatabaseMock.Setup(x => x.GetCollection<BsonDocument>("Orders", null)).Returns(orderCollectionMock.Object);

            _target = new OrderRepository(mongoDbClientMock.Object, mapperMock.Object, bsonMapperMock.Object);
        }

        [TestMethod]
        public void ShouldMapCartToPurchaseOrderOnCreateOrder()
        {
            _target.CreateOrder(cartMock.Object);

            mapperMock.Verify(x => x.Map<Cart, PurchaseOrder>(cartMock.Object));
        }

        [TestMethod]
        public void ShouldInsertPurchaseOrderToOrderCollectionOnCreateOrder()
        {
            _target.CreateOrder(cartMock.Object);

            orderCollectionMock.Verify(x => x.InsertOne(bsonDocument, null, default(CancellationToken)));
        }

        [TestMethod]
        public void ShouldReturnOrderIdOnCreeateOrder()
        {
            var actualOrderId = _target.CreateOrder(cartMock.Object);

            Assert.AreEqual(_expectedOrderId, actualOrderId);
        }
    }
}