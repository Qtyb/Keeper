using Common.Data.Exceptions;
using Common.EventBus.Interfaces;
using Common.Repository.Interfaces;
using Common.Service.Interfaces;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using Microsoft.Extensions.Logging;
using Places.Data.Entities;
using Places.Models.Dtos.Request;
using Places.Repositories.Repositories.Intefaces;
using Places.Services.Query.Interfaces;
using System.Threading.Tasks;

namespace Places.Services.Query
{
    public class PlaceCommandService : IPlaceCommandService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPlaceMappingService _placeMappingService;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextUserService _httpContextUserService;
        private readonly IEventBusPublisher _eventBusPublisher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PlaceQueryService> _logger;

        public PlaceCommandService(
            IPlaceRepository placeRepository,
            IPlaceMappingService placeMappingService,
            IUserRepository userRepository,
            IHttpContextUserService httpContextUserService,
            IEventBusPublisher eventBusPublisher,
            IUnitOfWork unitOfWork,
            ILogger<PlaceQueryService> logger)
        {
            _placeRepository = placeRepository;
            _placeMappingService = placeMappingService;
            _userRepository = userRepository;
            _httpContextUserService = httpContextUserService;
            _eventBusPublisher = eventBusPublisher;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> CreatePlace(CreatePlaceDto createPlaceDto)
        {
            _logger.LogInformation("{class}.{method} with dto = [{@dto}] Invoked", nameof(PlaceCommandService), nameof(CreatePlace), createPlaceDto);

            var userGuid = _httpContextUserService.GetUserGuid();
            var user = await _userRepository.GetByGuid(userGuid);
            var place = _placeMappingService.Map(createPlaceDto, user);

            _placeRepository.Add(place);
            await _unitOfWork.Commit();
            _logger.LogInformation("{entityName} with id = [{id}] has been created in local database", nameof(Place), place.Id);

            var @event = _placeMappingService.MapToPlaceCreatedEvent(place);
            _eventBusPublisher.Publish(@event);

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully created", nameof(Place), place.Id);

            return place.Id;
        }

        public async Task UpdatePlace(int id, UpdatePlaceDto updatePlaceDto)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(PlaceCommandService), nameof(UpdatePlace), id);

            var userGuid = _httpContextUserService.GetUserGuid();
            var place = await _placeRepository.GetById(id, userGuid);
            if (place is null || place.Deleted)
                throw new EntityNotFoundException<Place>($"Id = [{id}], UserGuid = [{userGuid}]");

            _placeMappingService.Map(updatePlaceDto, place);
            await _unitOfWork.Commit();
            _logger.LogInformation("{entityName} with id = [{id}] has been updated in local database", nameof(Place), place.Id);

            var @event = _placeMappingService.MapToPlaceUpdatedEvent(place);
            _eventBusPublisher.Publish(@event);

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully updated", nameof(Place), place.Id);
        }

        public async Task DeletePlace(int id)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(PlaceCommandService), nameof(DeletePlace), id);

            var userGuid = _httpContextUserService.GetUserGuid();
            var place = await _placeRepository.GetById(id, userGuid);
            if (place is null || place.Deleted)
                throw new EntityNotFoundException<Place>($"Id = [{id}], UserGuid = [{userGuid}]");

            place.Deleted = true;
            await _unitOfWork.Commit();
            _logger.LogInformation("{entityName} with id = [{id}] has been deleted from local database", nameof(Place), place.Id);

            var @event = _placeMappingService.MapToPlaceDeletedEvent(place);
            _eventBusPublisher.Publish(@event);

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully deleted", nameof(Place), place.Id);
        }
    }
}