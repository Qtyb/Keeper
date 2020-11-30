using Inventory.Data.Entities;
using Inventory.Models.Events.Places;

namespace Inventory.Services.Mappings.Interfaces
{
    public interface IPlaceMappingService
    {
        Place Map(PlaceCreatedEvent @event, int userId);

        void Map(PlaceUpdatedEvent @event, Place place);

        PlaceCreatedEvent Map(PlaceUpdatedEvent @event);
    }
}