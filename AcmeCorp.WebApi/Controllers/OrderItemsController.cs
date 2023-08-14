using Microsoft.AspNetCore.Mvc;

using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using AcmeCorp.Data.Repositories;

namespace AcmeCorp.WebApi.Controllers
{
    /// <summary>
    /// Manage Orders
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

        /// <summary>
        /// Add an Item to an Order
        /// </summary>
        /// <param name="orderItem"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OrderItem>> AddOrderItem(OrderItem orderItem)
        {
            OrderItem newItem = await _orderItemRepository.AddOrderItem(orderItem);
            return CreatedAtAction("GetCustomer", new { id = newItem.Id }, newItem);
        }

        /// <summary>
        /// Delete an Item from an Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            if (await _orderItemRepository.DeleteOrderItem(id) == false)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
