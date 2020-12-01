using Inventory.Models.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services.Query.Interfaces
{
    public interface IPlaceQueryService
    {
        Task<IEnumerable<PlaceListDto>> GetPlaces();
    }
}