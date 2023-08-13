using System.Diagnostics;
using Microsoft.Extensions.Logging;

using AcmeCorp.WebApi.Controllers;
using AcmeCorp.Data.Repositories.Mocks;
using Microsoft.Extensions.Logging.Abstractions;
using AcmeCorp.Data.Models;

namespace AcmeCorp.WebApi.Tests
{
    [TestClass]
    public class OrdersControllerTests
    {
        private OrdersController? _ordersController;

        [TestInitialize]
        public void Setup() 
        {
            _ordersController = new OrdersController(new MockOrderRepository(), new Logger<OrdersController>(new NullLoggerFactory()));
        }

        [TestMethod]
        public void AddOrder()
        {
            var order = new Order { Id = 1, ShipToContactId = 1 };
            //_ordersController.
        }

        [TestMethod]
        public void GetOrder()
        {
            var order = new Order { Id = 1, ShipToContactId = 1 };
            //_ordersController.
        }

        [TestMethod]
        public void UpdateOrder()
        {
            var order = new Order { Id = 1, ShipToContactId = 1 };
            //_ordersController.
        }

        [TestMethod]
        public void DeleteOrder()
        {
            var order = new Order { Id = 1, ShipToContactId = 1 };
            //_ordersController.
        }

    }
}