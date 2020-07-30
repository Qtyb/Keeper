using Inventory.Models.Dtos.Request.Thing;
using System.Threading.Tasks;

namespace Inventory.Services.Query.Interfaces
{
    public interface IThingCommandService
    {
        Task<int> CreateThing(CreateThingDto createThingDto);
        Task UpdateThing(int id, UpdateThingDto updateThingDto);
        Task DeleteThing(int id);
    }
}