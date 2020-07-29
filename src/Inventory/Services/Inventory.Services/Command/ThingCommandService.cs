using Common.Repository.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ThingQueryService> _logger;

        public ThingCommandService(
            IThingRepository thingRepository,
            IThingMappingService thingMappingService,
            IUnitOfWork unitOfWork,
            ILogger<ThingQueryService> logger)
        {
            _thingRepository = thingRepository;
            _thingMappingService = thingMappingService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> CreateThing(CreateThingDto createThingDto)
        {
            _logger.LogInformation("{class}.{method} with dto = [{@dto}] Invoked", nameof(ThingCommandService), nameof(CreateThing), createThingDto);
            var thing = _thingMappingService.Map(createThingDto);

            _thingRepository.Add(thing);
            await _unitOfWork.Commit();

            _logger.LogInformation("{entityName} has been successfully created", nameof(Thing));

            return thing.Id;
        }
    }
}