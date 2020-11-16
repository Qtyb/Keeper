using Common.Data.Exceptions;
using Common.Repository.Interfaces;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using Microsoft.Extensions.Logging;
using Places.Data.Entities;
using Places.Models.Dtos.Request;
using Places.Services.Query.Interfaces;
using System.Threading.Tasks;

namespace Places.Services.Query
{
    public class PlaceCommandService : IPlaceCommandService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPlaceMappingService _placeMappingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PlaceQueryService> _logger;

        public PlaceCommandService(
            IPlaceRepository placeRepository,
            IPlaceMappingService placeMappingService,
            IUnitOfWork unitOfWork,
            ILogger<PlaceQueryService> logger)
        {
            _placeRepository = placeRepository;
            _placeMappingService = placeMappingService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> CreatePlace(CreatePlaceDto createPlaceDto)
        {
            _logger.LogInformation("{class}.{method} with dto = [{@dto}] Invoked", nameof(PlaceCommandService), nameof(CreatePlace), createPlaceDto);
            var place = _placeMappingService.Map(createPlaceDto);

            _placeRepository.Add(place);
            await _unitOfWork.Commit();

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully created", nameof(Place), place.Id);

            return place.Id;
        }

        public async Task UpdatePlace(int id, UpdatePlaceDto updatePlaceDto)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(PlaceCommandService), nameof(UpdatePlace), id);

            var place = await _placeRepository.GetById(id);
            if (place is null || place.Deleted)
                throw new EntityNotFoundException<Place>($"Id = [{id}]");

            _placeMappingService.Map(updatePlaceDto, place);
            await _unitOfWork.Commit();

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully updated", nameof(Place), place.Id);
        }

        public async Task DeletePlace(int id)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(PlaceCommandService), nameof(DeletePlace), id);

            var place = await _placeRepository.GetById(id);
            if (place is null || place.Deleted)
                throw new EntityNotFoundException<Place>($"Id = [{id}]");

            place.Deleted = true;
            await _unitOfWork.Commit();

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully deleted", nameof(Place), place.Id);
        }
    }
}