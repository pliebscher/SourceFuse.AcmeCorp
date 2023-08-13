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

        public Task<Contact> AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContact(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> GetContacts(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
