using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

using AcmeCorp.WebApi.Controllers;
using AcmeCorp.Data.Repositories.Mocks;
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
            var result = _ordersController?.CreateOrder(order);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOrder()
        {
            var result = _ordersController?.GetOrder(1);
            Assert.IsNotNull(result?.Result.Value);
        }

    }
}