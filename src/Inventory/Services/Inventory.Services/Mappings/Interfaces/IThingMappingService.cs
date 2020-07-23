using Inventory.Data.Entities;
using Inventory.Models.Dtos.Response;

namespace Inventory.Services.Mappings.Interfaces
{
    public interface IThingMappingService
    {
        ThingListDto Map(Thing thing);
    }
}