using Microsoft.AspNetCore.Mvc;

using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;

namespace AcmeCorp.WebApi.Controllers
{
    /// <summary>
    /// Add/Remove Items in a Order
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// The .ctor
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="orderItemRepository"></param>
        /// <param name="logger"></param>
        public OrderItemsController(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, ILogger<OrderItemsController> logger)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get all Items in an Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>List of Items in the Order</returns>
        [HttpGet("{orderId}")]        
        public async Task<ActionResult<List<OrderItem>>> GetOrderItems(int orderId)
        {
            var items = await _orderItemRepository.GetOrderItems(orderId);

            if (items == null)
            {
                _logger.LogWarning("Order has no Items: " + orderId);
                return NotFound();
            }

            return items;
        }

    }
}
