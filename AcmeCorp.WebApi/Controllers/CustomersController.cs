using Microsoft.AspNetCore.Mvc;

using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;

namespace AcmeCorp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;

        public CustomersController(ICustomerRepository customerRepository, ILogger<CustomersController> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        [HttpGet]
        [EndpointDescription("Get all Customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _customerRepository.GetAllCustomers();
        }

        [HttpGet("{id}")]
        [EndpointDescription("Get a single Customer")]
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

        [HttpPut("{id}")]
        [EndpointDescription("Update a Customer")]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            customer = await _customerRepository.UpdateCustomer(customer);

            if (customer == null) { return NotFound(); }

            return NoContent();
        }

        [HttpPost]
        [EndpointDescription("Create a new Customer")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            Customer newCustomer = await _customerRepository.AddCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = newCustomer.Id }, newCustomer);
        }
 
        [HttpDelete("{id}")]
        [EndpointDescription("Delete a Customer")]
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
