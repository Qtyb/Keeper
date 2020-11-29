using Common.Repository.Interfaces;
using Inventory.Models.Events.Places;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Services.Handlers.Places
{
    public class PlaceDeletedEventHandler : IRequestHandler<PlaceDeletedEvent>
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPlaceMappingService _placeMappingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<PlaceDeletedEventHandler> _logger;

        public PlaceDeletedEventHandler(
            IPlaceRepository placeRepository,
            IPlaceMappingService placeMappingService,
            IUnitOfWork unitOfWork,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<PlaceDeletedEventHandler> logger)
        {
            _placeRepository = placeRepository;
            _placeMappingService = placeMappingService;
            _unitOfWork = unitOfWork;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public async Task<Unit> Handle(PlaceDeletedEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"---- Received {nameof(PlaceDeletedEvent)} message: Place.Guid = [{@event.Guid}] ----");

            var place = await _placeRepository.GetByGuid(@event.Guid);
            if (place == null)
            {
                return await HandleNotExistingPlace(@event);
            }

            place.Deleted = true;
            await _unitOfWork.Commit();

            _logger.LogInformation($"---- Deleted {nameof(PlaceDeletedEvent)} message: Place.Guid = [{@event.Guid}] ----");
            return await Task.FromResult(Unit.Value);
        }

        private async Task<Unit> HandleNotExistingPlace(PlaceDeletedEvent @event)
        {
            _logger.LogInformation($"---- Received {nameof(PlaceDeletedEvent)} contains non existing Place.Guid = [{@event.Guid}] ----");
            return await Task.FromResult(Unit.Value);
        }
    }
}