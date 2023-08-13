﻿using Microsoft.AspNetCore.Mvc;

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
        public OrdersController(IOrderRepository orderRepository, ILogger<ContactsController> logger)
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

    }
}