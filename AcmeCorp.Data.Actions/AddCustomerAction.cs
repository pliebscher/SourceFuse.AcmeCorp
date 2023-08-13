using AcmeCorp.Data.Context;
using AcmeCorp.Data.Models;

namespace AcmeCorp.Data.Actions
{
    public class AddCustomerAction // TODO: Inherit DataAction
    {

        private AcmeCorpDbContext _context;

        // Move the db context to the core
        public AddCustomerAction(AcmeCorpDbContext context) { 
            _context = context;
        }

        public void Execute(Customer customer) // TODO: Return DataActionResult
        {
            _context.Customers.Add(customer);
        }



    }
}