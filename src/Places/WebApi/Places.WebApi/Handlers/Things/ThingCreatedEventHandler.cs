using Common.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Places.Models.Events.Things;
using Places.Repositories.Repositories.Intefaces;
using Places.Services.Mappings.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Places.WebApi.Handlers.Things
{
    public class ThingCreatedEventHandler : IRequestHandler<ThingCreatedEvent>
    {
        private readonly IThingRepository _thingRepository;
        private readonly IThingMappingService _thingMappingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ThingCreatedEventHandler> _logger;

        public ThingCreatedEventHandler(
            IThingRepository thingRepository,
            IThingMappingService thingMappingService,
            IUnitOfWork unitOfWork,
            ILogger<ThingCreatedEventHandler> logger)
        {
            _thingRepository = thingRepository;
            _thingMappingService = thingMappingService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(ThingCreatedEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"---- Received {nameof(ThingCreatedEvent)} message: Thing.Guid = [{@event.Guid}] ----");

            var thing = await _thingRepository.GetByGuid(@event.Guid);
            if (thing != null)
            {
                _logger.LogInformation($"---- Thing with Guid = [{@event.Guid}] already exists. Skipping event ----");
                return await Task.FromResult(Unit.Value);
            }

            thing = _thingMappingService.Map(@event);
            _thingRepository.Add(thing);

            await _unitOfWork.Commit();

            _logger.LogInformation($"---- Saved {nameof(ThingCreatedEvent)} message: Thing.Guid = [{@event.Guid}] Thing.Id = [{thing.Id}]----");

            return await Task.FromResult(Unit.Value);
        }
    }
}