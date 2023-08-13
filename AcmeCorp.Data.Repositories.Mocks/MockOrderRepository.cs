using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;

namespace AcmeCorp.Data.Repositories.Mocks
{
    public class MockOrderRepository : IOrderRepository
    {

        private Dictionary<int, Order> _orders;

        public MockOrderRepository() 
        {
            _orders = new Dictionary<int, Order>();
        }

        public Task<Order> AddOrder(Order order)
        {
            _orders.Add(order.Id, order);
            return new Task<Order>(() => order);
        }

        public Task<bool> DeleteOrder(int id)
        {
            var removed = _orders.Remove(id);
            return new Task<bool>(() => removed); 
        }

        public Task<Order> GetOrder(int Id)
        {
            return new Task<Order>(() => _orders[Id]);
        }

        public Task<Order> UpdateOrder(Order order)
        {
            _orders[order.Id] = order;
            return new Task<Order>(() => order);
        }
    }
}
