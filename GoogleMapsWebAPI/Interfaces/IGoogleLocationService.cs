using GoogleMapsWebAPI.Models;
using System.Threading.Tasks;

namespace GoogleMapsWebAPI.Interfaces
{
    public interface IGoogleLocationService
    {
        Task<CoordinatesModel> GetLocation(AddressInputModel result);
    }
}
