using Inventory.Data.Entities;
using Inventory.Models.Dtos.Request.Thing;
using Inventory.Models.Dtos.Response;
using System.Collections.Generic;

namespace Inventory.Services.Mappings.Interfaces
{
    public interface IThingMappingService
    {
        IEnumerable<ThingListDto> Map(IEnumerable<Thing> thing);
        ThingDto Map(Thing thing);
        Thing Map(CreateThingDto createThingDto);
    }
}