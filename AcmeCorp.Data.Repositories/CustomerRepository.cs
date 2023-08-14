
using AcmeCorp.Data.Context;
using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Data.Repositories
{
    public class CustomerRepository : AcmeCorpDataRepository, ICustomerRepository
    {
        public CustomerRepository(AcmeCorpDataContext context) : base(context) { }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            Context.Customer.Add(customer);
            await Context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await Context.Customer.FindAsync(id);

            if (customer == null)
                return false;

            Context.Customer.Remove(customer);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await Context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
      
            return await Context.Customer.FindAsync(id);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            Context.Entry(customer).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // TODO: This needs to be handled...
                throw;
            }

            return customer;
        }
 
    }
}
