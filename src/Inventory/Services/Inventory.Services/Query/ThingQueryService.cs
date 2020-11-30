using Common.Data.Exceptions;
using Common.Service.Interfaces;
using Inventory.Data.Entities;
using Inventory.Models.Dtos.Response;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Mappings.Interfaces;
using Inventory.Services.Query.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inventory.Services.Query
{
    public class ThingQueryService : IThingQueryService
    {
        private readonly IThingRepository _thingRepository;
        private readonly IThingMappingService _thingMappingService;
        private readonly IHttpContextUserService _httpContextUserService;
        private readonly ILogger<ThingQueryService> _logger;

        public ThingQueryService(
            IThingRepository thingRepository,
            IThingMappingService thingMappingService,
            IHttpContextUserService httpContextUserService,
            ILogger<ThingQueryService> logger)
        {
            _thingRepository = thingRepository;
            _thingMappingService = thingMappingService;
            _httpContextUserService = httpContextUserService;
            _logger = logger;
        }

        public async Task<IEnumerable<ThingListDto>> GetThings()
        {
            _logger.LogInformation("{class}.{method} Invoked", nameof(ThingQueryService), nameof(GetThings));

            var userGuid = _httpContextUserService.GetUserGuid();
            var things = await _thingRepository.GetWithCategoriesAndCurrencies(userGuid);

            return _thingMappingService.Map(things);
        }

        public async Task<ThingDto> GetThing(int id)
        {
            _logger.LogInformation("{class}.{method} with id = [{id}] Invoked", nameof(ThingQueryService), nameof(GetThings), id);

            var userGuid = _httpContextUserService.GetUserGuid();
            var thing = await _thingRepository.GetById(id, userGuid);

            if (thing is null || thing.Deleted)
                throw new EntityNotFoundException<Thing>($"Id = [{id}], User Guid = [{userGuid}]");

            return _thingMappingService.MapToThingDto(thing);
        }
    }
}