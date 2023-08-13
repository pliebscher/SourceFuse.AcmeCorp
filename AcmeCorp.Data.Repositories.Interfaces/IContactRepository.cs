using AcmeCorp.Data.Models;

namespace AcmeCorp.Data.Repositories.Interfaces
{
    public interface IContactRepository
    {

        /// <summary>
        /// Add a new Contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>Id of new Contact</returns>
        public Task<Contact> AddContact(Contact contact);

        /// <summary>
        /// Get a Contact 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A Contact</returns>
        public Task<Contact> GetContact(int Id);

        /// <summary>
        /// Update a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>True if update was successful</returns>
        public Task<Contact> UpdateContact(Contact contact);

        /// <summary>
        /// Deletes a Contact (Soft)
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>True if delete was successful</returns>
        public Task<bool> DeleteContact(int id);

        /// <summary>
        /// Fetch all the Contacts for a company...
        /// </summary>
        /// <returns>All of em...</returns>
        public Task<List<Contact>> GetContacts(int customerId);

    }
}
