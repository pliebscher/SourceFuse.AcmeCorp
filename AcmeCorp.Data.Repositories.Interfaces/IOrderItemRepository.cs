using AcmeCorp.Data.Models;

namespace AcmeCorp.Data.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        /// <summary>
        /// Get items in an Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<List<OrderItem>> GetOrderItems(int orderId);

        /// <summary>
        /// Add an Item to an Order
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<OrderItem> AddOrderItem(OrderItem item);

        /// <summary>
        /// Delete an Item from an Order
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> DeleteOrderItem(int id);

    }
}
