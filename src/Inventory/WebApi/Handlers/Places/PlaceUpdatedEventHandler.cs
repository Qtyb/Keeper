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
    public class PlaceUpdatedEventHandler : IRequestHandler<PlaceUpdatedEvent>
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPlaceMappingService _placeMappingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<PlaceUpdatedEventHandler> _logger;

        public PlaceUpdatedEventHandler(
            IPlaceRepository placeRepository,
            IPlaceMappingService placeMappingService,
            IUnitOfWork unitOfWork,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<PlaceUpdatedEventHandler> logger)
        {
            _placeRepository = placeRepository;
            _placeMappingService = placeMappingService;
            _unitOfWork = unitOfWork;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public async Task<Unit> Handle(PlaceUpdatedEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"---- Received {nameof(PlaceUpdatedEvent)} message: Place.Guid = [{@event.Guid}] ----");

            var place = await _placeRepository.GetByGuid(@event.Guid);
            if (place == null)
            {
                return await HandleNotExistingPlace(@event);
            }

            _placeMappingService.Map(@event, place);
            await _unitOfWork.Commit();

            _logger.LogInformation($"---- Updated {nameof(PlaceUpdatedEvent)} message: Place.Guid = [{@event.Guid}] ----");

            return await Task.FromResult(Unit.Value);
        }

        private async Task<Unit> HandleNotExistingPlace(PlaceUpdatedEvent @event)
        {
            _logger.LogInformation($"---- Place with Guid = [{@event.Guid}] does not exists. Passing to create handler ----");
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(_placeMappingService.Map(@event));
            }

            return await Task.FromResult(Unit.Value);
        }
    }
}