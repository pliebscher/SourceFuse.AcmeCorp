using AcmeCorp.Data.Models;

namespace AcmeCorp.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {

        /// <summary>
        /// Fetch all Products
        /// </summary>
        /// <returns>All of em...</returns>
        Task<List<Product>> GetAllProducts();

    }
}
