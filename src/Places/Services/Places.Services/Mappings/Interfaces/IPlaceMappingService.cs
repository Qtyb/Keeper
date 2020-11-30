using Places.Data.Entities;
using Places.Models.Dtos.Request;
using Places.Models.Dtos.Response;
using Places.Models.Events.Places;
using System;
using System.Collections.Generic;

namespace Inventory.Services.Mappings.Interfaces
{
    public interface IPlaceMappingService
    {
        IEnumerable<PlaceListDto> Map(IEnumerable<Place> thing);

        PlaceDto MapToPlaceDto(Place thing);

        Place Map(CreatePlaceDto createPlaceDto, int userId);

        void Map(UpdatePlaceDto updatePlaceDto, Place thing);

        PlaceCreatedEvent MapToPlaceCreatedEvent(Place place);

        PlaceUpdatedEvent MapToPlaceUpdatedEvent(Place place);

        PlaceDeletedEvent MapToPlaceDeletedEvent(Place place);
    }
}