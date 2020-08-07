using Common.Data.Exceptions;
using Inventory.Data.Entities;
using Inventory.Models.Dtos.Response;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using Inventory.Services.Query.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services.Query
{
    public class ThingQueryService : IThingQueryService
    {
        private readonly IThingRepository _thingRepository;
        private readonly IThingMappingService _thingMappingService;
        private readonly ILogger<ThingQueryService> _logger;

        public ThingQueryService(
            IThingRepository thingRepository,
            IThingMappingService thingMappingService,
            ILogger<ThingQueryService> logger)
        {
            _thingRepository = thingRepository;
            _thingMappingService = thingMappingService;
            _logger = logger;
        }

        public async Task<IEnumerable<ThingListDto>> GetThings()
        {
            _logger.LogInformation("{class}.{method} Invoked", nameof(ThingQueryService), nameof(GetThings));
            var things = await _thingRepository.GetWithCategoriesAndCurrencies();

            return _thingMappingService.Map(things);
        }

        public async Task<ThingDto> GetThing(int id)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(ThingQueryService), nameof(GetThings), id);
            var thing = await _thingRepository.GetById(id);

            if (thing is null || thing.Deleted)
                throw new EntityNotFoundException<Thing>($"Id = [{id}]");

            return _thingMappingService.Map(thing);
        }
    }
}