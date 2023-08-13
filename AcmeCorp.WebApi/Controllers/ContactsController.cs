using Microsoft.AspNetCore.Mvc;

using AcmeCorp.Data.Models;
using AcmeCorp.Data.Repositories.Interfaces;
using AcmeCorp.Data.Repositories;

namespace AcmeCorp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;
        private readonly ILogger _logger;

        public ContactsController(IContactRepository contactRepository, ILogger<ContactsController> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [EndpointDescription("Get a single Contact")]
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

        [HttpPut]
        [EndpointDescription("Update a Contact")]
        public async Task<IActionResult> PutContact(Contact contact)
        {
            contact = await _contactRepository.UpdateContact(contact);

            if (contact == null) { return NotFound(); }

            return NoContent();
        }

        [HttpPost]
        [EndpointDescription("Create a new Contact")]
        public async Task<ActionResult<Customer>> PostContact(Contact contact)
        {
            Contact newContact = await _contactRepository.AddContact(contact);    
            return CreatedAtAction("GetCustomer", new { id = newContact.Id }, newContact);
        }

        [HttpDelete("{id}")]
        [EndpointDescription("Delete a Contact")]
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
