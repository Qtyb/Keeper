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
    public class ThingDeletedEventHandler : IRequestHandler<ThingDeletedEvent>
    {
        private readonly IThingRepository _thingRepository;
        private readonly IThingMappingService _thingMappingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<ThingDeletedEventHandler> _logger;

        public ThingDeletedEventHandler(
            IThingRepository thingRepository,
            IThingMappingService thingMappingService,
            IUnitOfWork unitOfWork,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<ThingDeletedEventHandler> logger)
        {
            _thingRepository = thingRepository;
            _thingMappingService = thingMappingService;
            _unitOfWork = unitOfWork;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public async Task<Unit> Handle(ThingDeletedEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"---- Received {nameof(ThingDeletedEvent)} message: Thing.Guid = [{@event.Guid}] ----");

            var thing = await _thingRepository.GetByGuid(@event.Guid);
            if (thing == null)
            {
                return await HandleNotExistingThing(@event);
            }

            thing.Deleted = true;
            await _unitOfWork.Commit();

            _logger.LogInformation($"---- Deleted {nameof(ThingDeletedEvent)} message: Thing.Guid = [{@event.Guid}] ----");
            return await Task.FromResult(Unit.Value);
        }

        private async Task<Unit> HandleNotExistingThing(ThingDeletedEvent @event)
        {
            _logger.LogInformation($"---- Received {nameof(ThingDeletedEvent)} contains non existing Thing.Guid = [{@event.Guid}] ----");
            return await Task.FromResult(Unit.Value);
        }
    }
}