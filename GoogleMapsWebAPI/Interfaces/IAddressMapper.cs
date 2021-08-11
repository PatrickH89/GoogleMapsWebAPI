using GoogleMapsWebAPI.Models;

namespace GoogleMapsWebAPI.Interfaces
{
    public interface IAddressMapper
    {
        AddressOutputModel AddressMapping(AddressInputModel address, CoordinatesModel coordinates);
    }
}
