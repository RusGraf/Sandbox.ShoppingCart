using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Sandbox.ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.ShoppingCart.Models;
using System.Web.SessionState;
using System.Web;

namespace Sandbox.ShoppingCart.Integration.Tests
{
    [TestClass]
    [Ignore]
    public class CartRepositotyTest
    {
        private ICartRepository _target;
        private HttpSessionState _session;

        [TestInitialize]
        public void Initialize()
        {
            //SetupMongoCart();//need to write method
            _target = new CartRepository();
            _session = HttpContext.Current.Session;
        }

        [TestMethod]
        public void GivenNotExistingProductId_WhenAddToCart_ThenProductAddedToSession()
        {
            Product product = new Product
            {
                ProductId = "NotExisting123"
            };

            _target.AddToCart(product);
            Product actualProduct = GetProductFromSession(product.ProductId);

            Assert.AreSame(product, actualProduct);
        }

        private Product GetProductFromSession(string productId)
        {
            if (_session["ShoppingCart"] == null)
            {
                return null;
            }
            List<CartProduct> shoppingCart = (List<CartProduct>)_session["ShoppingCart"];
            return shoppingCart.SingleOrDefault(x => x.ProductId.Equals(productId));
        }
    }
}
