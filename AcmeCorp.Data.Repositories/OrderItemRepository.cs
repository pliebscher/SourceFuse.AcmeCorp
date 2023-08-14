using AcmeCorp.Data.Context;
using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Data.Repositories
{
    public class OrderItemRepository : AcmeCorpDataRepository, IOrderItemRepository
    {
        public OrderItemRepository(AcmeCorpDataContext context) : base(context)
        {
        }

        public async Task<OrderItem> AddOrderItem(OrderItem item)
        {
            Context.OrderItem.Add(item);
            await Context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteOrderItem(int id)
        {
            var item = await Context.OrderItem.FindAsync(id);

            if (item == null)
                return false;

            Context.OrderItem.Remove(item);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            var orders = await Context.OrderItem.ToListAsync();
            var orderItems = orders.Where((item) => item.OrderId == orderId);
            return new List<OrderItem>(orderItems);
        }
    }
}
