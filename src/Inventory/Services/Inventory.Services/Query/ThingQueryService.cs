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
            var things = await _thingQueryRepository.GetAll();

            var result = new List<ThingListDto>();
            things.ToList().ForEach(t => result.Add(_thingMappingService.Map(t)));

            return result;
        }
    }
}
