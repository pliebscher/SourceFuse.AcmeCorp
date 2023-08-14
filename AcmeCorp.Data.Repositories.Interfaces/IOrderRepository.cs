using AcmeCorp.Data.Models;

namespace AcmeCorp.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Add a new Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Id of new Order</returns>
        public Task<Order> AddOrder(Order order);

        /// <summary>
        /// Get an Order 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>An Order</returns>
        public Task<Order> GetOrder(int id);

        /// <summary>
        /// Get all Orders for a Contact 
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns>An Order</returns>
        public Task<List<Order>> GetOrders(int contactId);

        /// <summary>
        /// Update an Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>True if update was successful</returns>
        public Task<Order> UpdateOrder(Order order);

        /// <summary>
        /// Deletes an Order (Soft)
        /// </summary>
        /// <param name="order"></param>
        /// <returns>True if delete was successful</returns>
        public Task<bool> DeleteOrder(int id);
    }
}
