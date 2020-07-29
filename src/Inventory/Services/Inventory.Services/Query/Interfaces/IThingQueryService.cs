using Inventory.Models.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services.Query.Interfaces
{
    public interface IThingQueryService
    {
        Task<IEnumerable<ThingListDto>> GetThings();
        Task<ThingDto> GetThing(int id);
    }
}