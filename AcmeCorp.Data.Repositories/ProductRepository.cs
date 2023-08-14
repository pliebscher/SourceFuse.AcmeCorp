using AcmeCorp.Data.Context;
using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Data.Repositories
{
    public class ProductRepository : AcmeCorpDataRepository, IProductRepository
    {
        public ProductRepository(AcmeCorpDataContext context) : base(context) { }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Context.Product.ToListAsync();
        }
    }
}
