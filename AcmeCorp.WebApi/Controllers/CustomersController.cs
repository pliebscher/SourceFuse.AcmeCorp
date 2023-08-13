using Microsoft.AspNetCore.Mvc;

using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;

namespace AcmeCorp.WebApi.Controllers
{
    /// <summary>
    /// Manage Customers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// The .ctor
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="logger"></param>
        public CustomersController(ICustomerRepository customerRepository, ILogger<CustomersController> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <returns>A list of Customers</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _customerRepository.GetAllCustomers();
        }

        /// <summary>
        /// Get a single Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Customer</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomer(id);

            if (customer == null)
            {
                _logger.LogWarning("Customer Not Found: " + id);
                return NotFound();
            }

            return customer;
        }

        /// <summary>
        /// Update a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>The updated Customer</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            customer = await _customerRepository.UpdateCustomer(customer);

            if (customer == null) { return NotFound(); }

            return NoContent();
        }

        /// <summary>
        /// Create a new Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>The new Customer</returns>
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            Customer newCustomer = await _customerRepository.AddCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = newCustomer.Id }, newCustomer);
        }

        /// <summary>
        /// Delete a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await _customerRepository.DeleteCustomer(id) == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
