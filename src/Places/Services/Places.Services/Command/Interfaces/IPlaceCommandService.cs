using Places.Models.Dtos.Request;
using System.Threading.Tasks;

namespace Places.Services.Query.Interfaces
{
    public interface IPlaceCommandService
    {
        Task<int> CreatePlace(CreatePlaceDto createPlaceDto);

        Task UpdatePlace(int id, UpdatePlaceDto updatePlaceDto);

        Task DeletePlace(int id);
    }
}