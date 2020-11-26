using Inventory.Data.Entities;
using Inventory.Models.Events.Places;
using Inventory.Services.Mappings.Interfaces;

namespace Inventory.Services.Mappings
{
    public class PlaceMappingService : IPlaceMappingService
    {
        public Place Map(PlaceCreatedEvent @event)
        {
            return new Place
            {
                Guid = @event.Guid,
                Name = @event.Name
            };
        }

        public void Map(PlaceUpdatedEvent @event, Place place)
        {
            place.Name = @event.Name;
        }
    }
}