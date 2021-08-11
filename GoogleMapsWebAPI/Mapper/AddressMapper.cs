using GoogleMapsWebAPI.Interfaces;
using GoogleMapsWebAPI.Models;

namespace GoogleMapsWebAPI.Mapper
{
    public class AddressMapper : IAddressMapper
    {
        public AddressOutputModel AddressMapping(AddressInputModel address, CoordinatesModel coordinates)
        {
            if (address == null || coordinates == null)
            {
                return null;
            }
            return new AddressOutputModel()
            {
                Street = address.Street,
                StreetNumber = address.StreetNumber,
                PostCode = address.PostCode,
                City = address.City,
                Country = address.Country,
                Latitude = coordinates.Latitude,
                Longitude = coordinates.Longitude
            };
        }
    }
}
