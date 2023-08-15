using Microsoft.AspNetCore.Mvc;

using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;

namespace AcmeCorp.WebApi.Controllers
{
    /// <summary>
    /// Manage Orders
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// The .ctor
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="logger"></param>
        public OrdersController(IOrderRepository orderRepository, ILogger<OrdersController> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get a single Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An Order</returns>
        [HttpGet("{id}")]
          public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);

            if (order == null)
            {
                _logger.LogWarning("Order Not Found: " + id);
                return NotFound();
            }

            return order;
        }

        /// <summary>
        /// Gets all the Contacts orders
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns>A list of Orders</returns>
        [HttpGet("/Contact/{contactId}")]
        public async Task<ActionResult<List<Order>>> GetOrders(int contactId)
        {
            var orders = await _orderRepository.GetOrders(contactId);

            if (orders == null || orders?.Count == 0)
            {
                _logger.LogWarning("Orders Not Found: " + contactId);
                return NotFound();
            }

            return orders;
        }

        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>The new Order</returns>
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            Order newOrder = await _orderRepository.AddOrder(order);
            return CreatedAtAction("GetOrder", new { id = newOrder.Id }, newOrder);
        }

    }
}
