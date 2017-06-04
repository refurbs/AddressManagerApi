using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Demo.AddressManager.Data;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.AddressManager.WebApi
{
    /// <summary>
    /// Contact Controller class
    /// </summary>
    [Route("api/[controller]")]
    public class ContactsController : BaseController
    {

        private readonly IAddressManagerRepository _repository;
        private readonly ILogger<ContactsController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public ContactsController(IAddressManagerRepository repository, 
            ILogger<ContactsController> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var contacts = _repository.GetAllContacts();
            if (contacts == null)
            {
                // returns 404 response
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ContactModel>>(contacts));
        }

        /// <summary>
        /// Gets a specified Contact
        /// </summary>
        /// <param name="id">The contact details</param>
        /// <param name="excludeAddress">When true, excludes the address details from result</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "ContactGet")]
        public IActionResult Get(long id, bool excludeAddress = false)
        {

            try
            {
                IContact contact = null;

                if (!excludeAddress)
                {
                    contact = _repository.GetContactWithAddresses(id);

                    if (contact == null)
                    {
                        // returns 404 response
                        return NotFound();
                    }

                    return Ok(_mapper.Map<ContactWithAddressModel>(contact));
                }
                else
                {
                    contact = _repository.GetContact(id);

                    if (contact == null)
                    {
                        // returns 404 response
                        return NotFound();
                    }

                    return Ok(_mapper.Map<ContactModel>(contact));
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex}");
            }

            // returns 400 response
            return BadRequest();

        }

        /// <summary>
        /// Creates a new Contact
        /// </summary>
        /// <param name="contactModel">The contact details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] ContactModel contactModel)
        {
            if (contactModel == null)
            {
                // returns 400 response
                return BadRequest();
            }

            var contact = _mapper.Map<Contact>(contactModel);

            _repository.Create(contact);
            _repository.SaveChanges();

            // CreatedAtRoute returns 201 response
            return CreatedAtRoute("ContactGet", new { id = contact.Id }, _mapper.Map<ContactModel>(contact));
        }

        /// <summary>
        /// Updates a specified Contact
        /// </summary>
        /// <param name="id">The contact id</param>
        /// <param name="contactModel">The contact details</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ContactModel contactModel)
        {
            if (contactModel == null )
            {
                // returns 400 response
                return BadRequest();
            }

            var contact = _repository.GetContact(id);
            if (contact == null)
            {
                // returns 404 response
                return NotFound();
            }

            contact.FirstName = contactModel.FirstName;
            contact.LastName = contactModel.FirstName;

            _repository.Update(contact);
            _repository.SaveChanges();

            // returns 204 response
            return new NoContentResult();
        }

        /// <summary>
        /// Deletes a specified Contact
        /// </summary>
        /// <param name="id">The Contact id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var contact = _repository.GetContact(id);
            if (contact == null)
            {
                // returns 404 response
                return NotFound();
            }

            _repository.Delete(contact);
            _repository.SaveChanges();

            // returns 204 response
            return new NoContentResult();
        }
    }
}
