using GoogleMapsWebAPI.Interfaces;
using GoogleMapsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleMapsWebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        //------------------------------------------------------------------
        // dependency injection: declaration
        private IAddressDatabaseService _databaseService;
        private IGoogleLocationService _locationService;
        private IAddressMapper _addressMapper;

        //------------------------------------------------------------------
        // dependency injection: initialization
        public AddressController(IAddressDatabaseService DatabaseService, IGoogleLocationService googleLocation, IAddressMapper Mapper)
        {
            _databaseService = DatabaseService;
            _locationService = googleLocation;
            _addressMapper = Mapper;
        }

        //------------------------------------------------------------------
        // GET ~/api/Address/GetAddresses
        [HttpGet("GetAddresses")]
        public ActionResult<IEnumerable<AddressOutputModel>> GetAddresses()
        {
            return Ok(_databaseService.GetAddresses());
        }

        //------------------------------------------------------------------
        // GET ~/api/Address/SelectAddress
        [HttpGet("SelectAddress/{id}")]
        public ActionResult<AddressOutputModel> SelectAddress(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            AddressOutputModel selectedAddress = _databaseService.SelectAddress(id);
            return Ok(selectedAddress);
        }

        //------------------------------------------------------------------
        // POST ~/api/Address/AddAddress
        [HttpPost("AddAddress")]
        public async Task<ActionResult> AddAddress([FromBody] AddressInputModel address)
        {
            // call method: get longitude and latitude from geocoding API
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            CoordinatesModel coordinates = await _locationService.GetLocation(address);

            // call method: combine coordinates and address-data to newAddress object
            if (coordinates == null)
            {
                return BadRequest();
            }
            AddressOutputModel newAddress = _addressMapper.AddressMapping(address, coordinates);

            // call method: add newAddress object to database
            if (newAddress == null)
            {
                return BadRequest();
            }
            return Ok(_databaseService.InsertAddress(newAddress));
        }

        //------------------------------------------------------------------
        // PUT ~/api/UpdateAddress/123
        [HttpPut("UpdateAddress/{id}")]
        public async Task<ActionResult> UpdateAddress(int id, [FromBody] AddressInputModel newProperties)
        {
            // call method: get longitude and latitude from geocoding API
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            CoordinatesModel coordinates = await _locationService.GetLocation(newProperties);

            // call method: combine coordinates and address-data to newAddress object
            if (coordinates == null)
            {
                return BadRequest();
            }
            AddressOutputModel toReplaceAddress = _addressMapper.AddressMapping(newProperties, coordinates);

            // call method: add object to database
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_databaseService.UpdateAddress(id, toReplaceAddress));
        }

        //------------------------------------------------------------------
        // DELETE ~/api/Address/DeleteAddress/100
        [HttpDelete("DeleteAddress/{id}")]
        public ActionResult<AddressOutputModel> DeleteAddress(int id)
        {
            return Ok(_databaseService.DeleteAddress(id));
        }
    }
}
