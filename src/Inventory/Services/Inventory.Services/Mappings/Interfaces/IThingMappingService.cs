using Inventory.Data.Entities;
using Inventory.Models.Dtos.Request.Thing;
using Inventory.Models.Dtos.Response;
using Inventory.Models.Events.Things;
using System.Collections.Generic;

namespace Inventory.Services.Mappings.Interfaces
{
    public interface IThingMappingService
    {
        IEnumerable<ThingListDto> Map(IEnumerable<Thing> thing);

        ThingDto MapToThingDto(Thing thing);

        Thing Map(CreateThingDto createThingDto, int userId);

        void Map(UpdateThingDto updateThingDto, Thing thing);

        ThingCreatedEvent MapToThingCreatedEvent(Thing thing);

        ThingUpdatedEvent MapToThingUpdatedEvent(Thing thing);

        ThingDeletedEvent MapToThingDeletedEvent(Thing plathingce);
    }
}