using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Demo.AddressManager.Data;
//using Microsoft.AspNetCore.Http.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.AddressManager.WebApi
{
    [Route("api/Contacts/{id}/Addresses")]
    public class ContactAddressesController : BaseController
    {

        private readonly IAddressManagerRepository _repository;
        private readonly ILogger<ContactAddressesController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public ContactAddressesController(IAddressManagerRepository repository, 
            ILogger<ContactAddressesController> logger, 
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the current and previous Addresses of the specified Contact
        /// </summary>
        /// <param name="id">The contact id</param>
        /// <returns></returns>
        [HttpGet(Name = "ContactAddressesGet")]
        public IActionResult Get(int id)
        {
            var addresses = _repository.GetAddressesByContactId(id);

            return Ok(_mapper.Map<IEnumerable<AddressModel>>(addresses));
        }

        /// <summary>
        /// Creates a new Address and makes it the current Address of the specified Contact
        /// </summary>
        /// <param name="id">The contact id</param>
        /// <param name="addressModel">The address details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(int id, [FromBody] AddressModel addressModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the current Address of the specified Contact using an existing Address
        /// </summary>
        /// <param name="id">The Contact id</param>
        /// <param name="addressModel">The address details</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(long id, [FromBody] AddressModel addressModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dereferences the current address from the specified Contact
        /// </summary>
        /// <param name="id">The Contact id</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
