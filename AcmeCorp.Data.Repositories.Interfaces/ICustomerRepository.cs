using AcmeCorp.Data.Models;

namespace AcmeCorp.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Add a new Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Id of new Customer</returns>
        public Task<Customer> AddCustomer(Customer customer);

        /// <summary>
        /// Get a Customer 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A Customer</returns>
        public Task<Customer> GetCustomer(int Id);

        /// <summary>
        /// Update a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>True if update was successful</returns>
        public Task<Customer> UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes a Customer (Soft)
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>True if delete was successful</returns>
        public Task<bool> DeleteCustomer(int id);

        /// <summary>
        /// Fetch all the customers... Generally not a great idea!
        /// </summary>
        /// <returns>All of em...</returns>
        public Task<List<Customer>> GetAllCustomers();

    }
}