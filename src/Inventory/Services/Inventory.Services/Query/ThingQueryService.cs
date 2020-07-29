using Common.Data.Exceptions;
using Inventory.Data.Entities;
using Inventory.Models.Dtos.Response;
using Inventory.Repositories.Query.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using Inventory.Services.Query.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.Query
{
    public class ThingQueryService : IThingQueryService
    {
        private readonly IThingQueryRepository _thingQueryRepository;
        private readonly IThingMappingService _thingMappingService;
        private readonly ILogger<ThingQueryService> _logger;

        public ThingQueryService(
            IThingQueryRepository thingQueryRepository,
            IThingMappingService thingMappingService,
            ILogger<ThingQueryService> logger)
        {
            _thingQueryRepository = thingQueryRepository;
            _thingMappingService = thingMappingService;
            _logger = logger;
        }


        public async Task<IEnumerable<ThingListDto>> GetThings()
        {
            _logger.LogInformation("{class}.{method} Invoked", nameof(ThingQueryService), nameof(GetThings));
            var things = await _thingQueryRepository.GetAll();

            return _thingMappingService.Map(things);
        }
        public async Task<ThingDto> GetThing(int id)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(ThingQueryService), nameof(GetThings), id);
            var thing = await _thingQueryRepository.GetById(id);

            if (thing is null)
                throw new EntityNotFoundException<Thing>($"Id = [{id}]");

            return _thingMappingService.Map(thing);
        }
    }
}
