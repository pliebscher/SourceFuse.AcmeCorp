using AcmeCorp.Data.Context;
using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Data.Repositories
{
    public class OrderItemRepository : AcmeCorpDataContext, IOrderItemRepository
    {
        public OrderItemRepository(DbContextOptions<AcmeCorpDataContext> options) : base(options)
        {
        }
        public async Task<int> AddOrderItem(OrderItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOrderItem(OrderItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
