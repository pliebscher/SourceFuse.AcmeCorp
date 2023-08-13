using Microsoft.AspNetCore.Mvc;

using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;

namespace AcmeCorp.WebApi.Controllers
{
    /// <summary>
    /// Manage Customer Contacts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// The .ctor
        /// </summary>
        /// <param name="contactRepository"></param>
        /// <param name="logger"></param>
        public ContactsController(IContactRepository contactRepository, ILogger<ContactsController> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get a single Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Contact</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactRepository.GetContact(id);

            if (contact == null)
            {
                _logger.LogWarning("Contact Not Found: " + id);
                return NotFound();
            }

            return contact;
        }

        /// <summary>
        /// Update a Contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>The updated Contact</returns>
        [HttpPut]
        public async Task<IActionResult> PutContact(Contact contact)
        {
            contact = await _contactRepository.UpdateContact(contact);

            if (contact == null) { return NotFound(); }

            return NoContent();
        }

        /// <summary>
        /// Create a new Contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>The new Contact</returns>
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            Contact newContact = await _contactRepository.AddContact(contact);    
            return CreatedAtAction("GetCustomer", new { id = newContact.Id }, newContact);
        }

        /// <summary>
        /// Delete a Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (await _contactRepository.DeleteContact(id) == false)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
