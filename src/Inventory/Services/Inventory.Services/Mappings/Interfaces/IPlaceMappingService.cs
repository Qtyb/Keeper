using Inventory.Data.Entities;
using Inventory.Models.Events.Places;

namespace Inventory.Services.Mappings.Interfaces
{
    public interface IPlaceMappingService
    {
        Place Map(PlaceCreatedEvent @event);

        void Map(PlaceUpdatedEvent @event, Place place);
    }
}