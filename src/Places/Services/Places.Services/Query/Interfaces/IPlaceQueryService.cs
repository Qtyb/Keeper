using Places.Models.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Places.Services.Query.Interfaces
{
    public interface IPlaceQueryService
    {
        Task<IEnumerable<PlaceListDto>> GetPlaces();

        Task<PlaceDto> GetPlace(int id);
    }
}