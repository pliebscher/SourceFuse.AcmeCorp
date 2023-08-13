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

    }
}
