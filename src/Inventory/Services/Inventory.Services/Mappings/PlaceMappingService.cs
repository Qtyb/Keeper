using Inventory.Data.Entities;
using Inventory.Models.Events.Places;
using Inventory.Services.Mappings.Interfaces;

namespace Inventory.Services.Mappings
{
    public class PlaceMappingService : IPlaceMappingService
    {
        public Place Map(PlaceCreatedEvent @event, int userId)
        {
            return new Place
            {
                Guid = @event.Guid,
                Name = @event.Name,
                UserId = userId
            };
        }

        public void Map(PlaceUpdatedEvent @event, Place place)
        {
            place.Name = @event.Name;
        }

        public PlaceCreatedEvent Map(PlaceUpdatedEvent @event)
        {
            return new PlaceCreatedEvent
            {
                Guid = @event.Guid,
                Name = @event.Name,
                ParentPlaceGuid = @event.ParentPlaceGuid
            };
        }
    }
}