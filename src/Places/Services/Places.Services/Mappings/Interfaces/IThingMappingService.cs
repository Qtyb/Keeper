using Places.Data.Entities;
using Places.Models.Events.Things;

namespace Places.Services.Mappings.Interfaces
{
    public interface IThingMappingService
    {
        Thing Map(ThingCreatedEvent @event);

        void Map(ThingUpdatedEvent @event, Thing thing);

        ThingCreatedEvent Map(ThingUpdatedEvent @event);
    }
}