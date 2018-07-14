using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sandbox.ShoppingCart.Repositories;
using Sandbox.ShoppingCart.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.ShoppingCart.Repositories.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private IOrderRepository _target;        

        [TestInitialize]
        public void Initialize()
        {           
            //_target = new OrderRepository();

        }
    }
}