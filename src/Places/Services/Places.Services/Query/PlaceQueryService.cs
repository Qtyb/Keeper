using Common.Data.Exceptions;
using Common.Service.Interfaces;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using Microsoft.Extensions.Logging;
using Places.Data.Entities;
using Places.Models.Dtos.Response;
using Places.Services.Query.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Places.Services.Query
{
    public class PlaceQueryService : IPlaceQueryService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPlaceMappingService _placeMappingService;
        private readonly IHttpContextUserService _httpContextUserService;
        private readonly ILogger<PlaceQueryService> _logger;

        public PlaceQueryService(
            IPlaceRepository thingRepository,
            IPlaceMappingService thingMappingService,
            IHttpContextUserService httpContextUserService,
            ILogger<PlaceQueryService> logger)
        {
            _placeRepository = thingRepository;
            _placeMappingService = thingMappingService;
            _httpContextUserService = httpContextUserService;
            _logger = logger;
        }

        public async Task<IEnumerable<PlaceListDto>> GetPlaces()
        {
            _logger.LogInformation("{class}.{method} Invoked", nameof(PlaceQueryService), nameof(GetPlaces));

            var userGuid = _httpContextUserService.GetUserGuid();
            var places = await _placeRepository.GetPlaces(userGuid);

            return _placeMappingService.Map(places);
        }

        public async Task<PlaceDto> GetPlace(int id)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(PlaceQueryService), nameof(GetPlaces), id);

            var userGuid = _httpContextUserService.GetUserGuid();
            var place = await _placeRepository.GetPlaceWithParent(id, userGuid);

            if (place is null || place.Deleted)
                throw new EntityNotFoundException<Place>($"Id = [{id}], UserGuid = [{userGuid}]");

            return _placeMappingService.MapToPlaceDto(place);
        }
    }
}