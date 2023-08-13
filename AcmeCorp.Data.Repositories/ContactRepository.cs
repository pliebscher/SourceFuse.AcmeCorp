using AcmeCorp.Data.Context;
using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Data.Repositories
{
    public class ContactRepository : AcmeCorpDataRepository, IContactRepository
    {
        public ContactRepository(AcmeCorpDataContext context) : base(context)
        {
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            Context.Contact.Add(contact);
            await Context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await Context.Contact.FindAsync(id);

            if (contact == null)
                return false;

            Context.Contact.Remove(contact);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<Contact> GetContact(int id)
        {
            return await Context.Contact.FindAsync(id);
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            // TODO: Mahe sure the contact exists...

            Context.Entry(contact).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // TODO: This needs to be handled...
                throw;
            }

            return contact;
        }
    }
}
