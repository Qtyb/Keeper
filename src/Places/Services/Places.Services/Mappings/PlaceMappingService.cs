using Inventory.Services.Mappings.Interfaces;
using Places.Data.Entities;
using Places.Models.Dtos.Request;
using Places.Models.Dtos.Response;
using Places.Models.Events.Places;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services.Mappings
{
    public class PlaceMappingService : IPlaceMappingService
    {
        public PlaceDto MapToPlaceDto(Place place)
        {
            return new PlaceDto
            {
                Id = place.Id,
                Name = place.Name,
                Description = place.Description,
                ParentPlaceId = place.ParentPlaceId,
                ParentPlaceName = place.ParentPlace?.Name
            };
        }

        public IEnumerable<PlaceListDto> Map(IEnumerable<Place> place)
        {
            return place.Select(placeElement => new PlaceListDto()
            {
                Id = placeElement.Id,
                Name = placeElement.Name,
                ParentPlaceId = placeElement.ParentPlaceId,
                ParentPlaceName = placeElement.ParentPlace?.Name
            }).ToList();
        }

        public Place Map(CreatePlaceDto createPlaceDto)
        {
            return new Place()
            {
                Name = createPlaceDto.Name,
                Description = createPlaceDto.Description,
                ParentPlaceId = createPlaceDto.ParentPlaceId,
            };
        }

        public void Map(UpdatePlaceDto updatePlaceDto, Place place)
        {
            place.Name = string.IsNullOrEmpty(updatePlaceDto.Name) ? place.Name : updatePlaceDto.Name;
            place.Description = string.IsNullOrEmpty(updatePlaceDto.Description) ? place.Description : updatePlaceDto.Description;
            place.ParentPlaceId = updatePlaceDto.ParentPlaceId;
        }

        public PlaceCreatedEvent MapToPlaceCreatedEvent(Place place)
        {
            return new PlaceCreatedEvent
            {
                Guid = place.Guid,
                Name = place.Name,
                ParentPlaceGuid = place.ParentPlace?.Guid
            };
        }

        public PlaceUpdatedEvent MapToPlaceUpdatedEvent(Place place)
        {
            return new PlaceUpdatedEvent
            {
                Guid = place.Guid,
                Name = place.Name,
                ParentPlaceGuid = place.ParentPlace.Guid
            };
        }

        public PlaceDeletedEvent MapToPlaceDeletedEvent(Place place)
        {
            return new PlaceDeletedEvent
            {
                Guid = place.Guid
            };
        }
    }
}