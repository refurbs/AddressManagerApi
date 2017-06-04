using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Demo.AddressManager.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.AddressManager.WebApi
{
    [Route("api/[controller]")]
    public class AddressesController : BaseController
    {

        private readonly IAddressManagerRepository _repository;
        private readonly ILogger<AddressesController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        public AddressesController(IAddressManagerRepository repository, 
            ILogger<AddressesController> logger, 
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Addresses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var addresses = _repository.GetAllAddresses();

            return Ok(_mapper.Map<IEnumerable<AddressModel>>(addresses));
        }

        /// <summary>
        /// Gets a specified Address
        /// </summary>
        /// <param name="id">The address id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "AddressGet")]
        public IActionResult Get(long id)
        {

            try
            {
                IAddress address = _repository.GetAddress(id);

                if (address == null)
                {
                    // returns 404 response
                    return NotFound();
                }

                return Ok(_mapper.Map<AddressModel>(address));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex}");
            }

            // returns 400 response
            return BadRequest();

        }

        /// <summary>
        /// Creates a new Address
        /// </summary>
        /// <param name="addressModel">The address details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] AddressModel addressModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified address
        /// </summary>
        /// <param name="id">The address id</param>
        /// <param name="addressModel">The address details</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(long id, [FromBody] AddressModel addressModel)
        {
            throw new NotImplementedException();
        }
    }
}
