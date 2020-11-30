using Common.Repository.Interfaces;
using Inventory.Models.Events.Places;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Services.Handlers.Places
{
    public class PlaceCreatedEventHandler : IRequestHandler<PlaceCreatedEvent>
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPlaceMappingService _placeMappingService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PlaceCreatedEventHandler> _logger;

        public PlaceCreatedEventHandler(
            IPlaceRepository placeRepository,
            IPlaceMappingService placeMappingService,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            ILogger<PlaceCreatedEventHandler> logger)
        {
            _placeRepository = placeRepository;
            _placeMappingService = placeMappingService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(PlaceCreatedEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"---- Received {nameof(PlaceCreatedEvent)} message: Place.Guid = [{@event.Guid}] ----");

            var place = await _placeRepository.GetByGuid(@event.Guid);
            if (place != null)
            {
                _logger.LogInformation($"---- Place with Guid = [{@event.Guid}] already exists. Skipping event ----");
                return await Task.FromResult(Unit.Value);
            }

            var user = await _userRepository.GetByGuid(@event.UserGuid);
            place = _placeMappingService.Map(@event, user.Id);
            if (@event.ParentPlaceGuid != null)
            {
                var parentPlace = await _placeRepository.GetByGuid((Guid)@event.ParentPlaceGuid);
                place.ParentLocationId = parentPlace.Id;
            }

            _placeRepository.Add(place);
            await _unitOfWork.Commit();

            _logger.LogInformation($"---- Saved {nameof(PlaceCreatedEvent)} message: Place.Guid = [{@event.Guid}] Place.Id = [{place.Id}]----");

            return await Task.FromResult(Unit.Value);
        }
    }
}