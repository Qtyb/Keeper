using Common.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Places.Models.Events.Things;
using Places.Repositories.Repositories.Intefaces;
using Places.Services.Mappings.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Places.WebApi.Handlers.Things
{
    public class ThingUpdatedEventHandler : IRequestHandler<ThingUpdatedEvent>
    {
        private readonly IThingRepository _thingRepository;
        private readonly IThingMappingService _thingMappingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<ThingUpdatedEventHandler> _logger;

        public ThingUpdatedEventHandler(
            IThingRepository thingRepository,
            IThingMappingService thingMappingService,
            IUnitOfWork unitOfWork,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<ThingUpdatedEventHandler> logger)
        {
            _thingRepository = thingRepository;
            _thingMappingService = thingMappingService;
            _unitOfWork = unitOfWork;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public async Task<Unit> Handle(ThingUpdatedEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"---- Received {nameof(ThingUpdatedEvent)} message: Thing.Guid = [{@event.Guid}] ----");

            var thing = await _thingRepository.GetByGuid(@event.Guid);
            if (thing == null)
            {
                return await HandleNotExistingThing(@event);
            }

            _thingMappingService.Map(@event, thing);
            await _unitOfWork.Commit();

            _logger.LogInformation($"---- Updated {nameof(ThingUpdatedEvent)} message: Thing.Guid = [{@event.Guid}] ----");

            return await Task.FromResult(Unit.Value);
        }

        private async Task<Unit> HandleNotExistingThing(ThingUpdatedEvent @event)
        {
            _logger.LogInformation($"---- Thing with Guid = [{@event.Guid}] does not exists. Passing to create handler ----");
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(_thingMappingService.Map(@event));
            }

            return await Task.FromResult(Unit.Value);
        }
    }
}