using Common.Data.Exceptions;
using Common.EventBus.Interfaces;
using Common.Repository.Interfaces;
using Common.Service.Interfaces;
using Inventory.Data.Entities;
using Inventory.Models.Dtos.Request.Thing;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using Inventory.Services.Query.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Inventory.Services.Query
{
    public class ThingCommandService : IThingCommandService
    {
        private readonly IThingRepository _thingRepository;
        private readonly IThingMappingService _thingMappingService;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextUserService _httpContextUserService;
        private readonly IEventBusPublisher _eventBusPublisher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ThingQueryService> _logger;

        public ThingCommandService(
            IThingRepository thingRepository,
            IThingMappingService thingMappingService,
            IUserRepository userRepository,
            IHttpContextUserService httpContextUserService,
            IEventBusPublisher eventBusPublisher,
            IUnitOfWork unitOfWork,
            ILogger<ThingQueryService> logger)
        {
            _thingRepository = thingRepository;
            _thingMappingService = thingMappingService;
            _userRepository = userRepository;
            _httpContextUserService = httpContextUserService;
            _eventBusPublisher = eventBusPublisher;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> CreateThing(CreateThingDto createThingDto)
        {
            _logger.LogInformation("{class}.{method} with dto = [{@dto}] Invoked", nameof(ThingCommandService), nameof(CreateThing), createThingDto);

            var userGuid = _httpContextUserService.GetUserGuid();
            var user = await _userRepository.GetByGuid(userGuid);
            var thing = _thingMappingService.Map(createThingDto, user.Id);

            _thingRepository.Add(thing);
            await _unitOfWork.Commit();
            _logger.LogInformation("{entityName} with id = [{id}] has been created in local database", nameof(Thing), thing.Id);

            var @event = _thingMappingService.MapToThingCreatedEvent(thing);
            _eventBusPublisher.Publish(@event);

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully created", nameof(Thing), thing.Id);
            return thing.Id;
        }

        public async Task UpdateThing(int id, UpdateThingDto updateThingDto)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(ThingCommandService), nameof(UpdateThing), id);

            var userGuid = _httpContextUserService.GetUserGuid();
            var thing = await _thingRepository.GetById(id, userGuid);
            if (thing is null || thing.Deleted)
                throw new EntityNotFoundException<Thing>($"Id = [{id}]");

            _thingMappingService.Map(updateThingDto, thing);
            await _unitOfWork.Commit();
            _logger.LogInformation("{entityName} with id = [{id}] has been updated in local database", nameof(Thing), thing.Id);

            var @event = _thingMappingService.MapToThingUpdatedEvent(thing);
            _eventBusPublisher.Publish(@event);

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully updated", nameof(Thing), thing.Id);
        }

        public async Task DeleteThing(int id)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(ThingCommandService), nameof(DeleteThing), id);

            var userGuid = _httpContextUserService.GetUserGuid();
            var thing = await _thingRepository.GetById(id, userGuid);
            if (thing is null || thing.Deleted)
                throw new EntityNotFoundException<Thing>($"Id = [{id}]");

            thing.Deleted = true;
            await _unitOfWork.Commit();
            _logger.LogInformation("{entityName} with id = [{id}] has been deleted in local database", nameof(Thing), thing.Id);

            var @event = _thingMappingService.MapToThingDeletedEvent(thing);
            _eventBusPublisher.Publish(@event);

            _logger.LogInformation("{entityName} with id = [{id}] has been successfully deleted", nameof(Thing), thing.Id);
        }
    }
}