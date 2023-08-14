using Microsoft.AspNetCore.Mvc;

using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using AcmeCorp.Data.Repositories;

namespace AcmeCorp.WebApi.Controllers
{
    /// <summary>
    /// Manage Products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// The .ctor
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="logger"></param>
        public ProductsController(IProductRepository productRepository, ILogger<CustomersController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        /// <summary>
        /// Gets all the Products for sale.
        /// </summary>
        /// <returns>A list of Products</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _productRepository.GetAllProducts();
        }
    }
}
