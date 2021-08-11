using GoogleMapsWebAPI.Models;
using System.Collections.Generic;

namespace GoogleMapsWebAPI.Interfaces
{
    // interfaces as skeleton -> a contract to use its still-empty methods
    public interface IAddressDatabaseService
    {
        //GET
        IEnumerable<AddressOutputModel> GetAddresses();

        // SELECT
        AddressOutputModel SelectAddress(int id);

        //INSERT
        AddressOutputModel InsertAddress(AddressOutputModel param);

        //UPDATE
        IEnumerable<AddressOutputModel> UpdateAddress(int id, AddressOutputModel addressUpdate);

        //DELETE
        AddressOutputModel DeleteAddress(int id);
    }
}
