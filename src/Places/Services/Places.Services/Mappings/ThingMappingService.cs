using Places.Data.Entities;
using Places.Models.Events.Things;
using Places.Services.Mappings.Interfaces;

namespace Places.Services.Mappings
{
    public class ThingMappingService : IThingMappingService
    {
        public Thing Map(ThingCreatedEvent @event)
        {
            return new Thing
            {
                Guid = @event.Guid,
                Name = @event.Name,
                Value = @event.Value
            };
        }

        public void Map(ThingUpdatedEvent @event, Thing thing)
        {
            thing.Name = @event.Name;
            thing.Value = @event.Value;
        }
    }
}