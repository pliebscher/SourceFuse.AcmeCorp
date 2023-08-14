using AcmeCorp.Data.Context;
using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Data.Repositories
{
    public class OrderRepository : AcmeCorpDataRepository, IOrderRepository
    {
        public OrderRepository(AcmeCorpDataContext context) : base(context)
        {
        }

        public async Task<Order> AddOrder(Order order)
        {
            Context.Order.Add(order);
            await Context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await Context.Order.FindAsync(id);

            if (order == null)
                return false;

            Context.Order.Remove(order);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await Context.Order.FindAsync(id);
        }

        public async Task<List<Order>> GetOrders(int contactId)
        {
            var orders = await Context.Order.ToListAsync();
            var ordersWithContactId = orders.Where((order) => order.ShipToContactId == contactId);
            return new List<Order>(ordersWithContactId);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            Context.Entry(order).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // TODO: This needs to be handled...
                throw;
            }

            return order;
        }
    }
}
