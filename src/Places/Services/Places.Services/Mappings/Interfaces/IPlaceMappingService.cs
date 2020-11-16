using Places.Data.Entities;
using Places.Models.Dtos.Request;
using Places.Models.Dtos.Response;
using System.Collections.Generic;

namespace Inventory.Services.Mappings.Interfaces
{
    public interface IPlaceMappingService
    {
        IEnumerable<PlaceListDto> Map(IEnumerable<Place> thing);

        PlaceDto Map(Place thing);

        Place Map(CreatePlaceDto createPlaceDto);

        void Map(UpdatePlaceDto updatePlaceDto, Place thing);
    }
}