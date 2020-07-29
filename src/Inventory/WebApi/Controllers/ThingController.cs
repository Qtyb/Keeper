using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data.Entities;
using Inventory.Models.Dtos.Request.Thing;
using Inventory.Models.Dtos.Response;
using Inventory.Services.Query.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inventory.Controllers
{
    [Route("api/things")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        private readonly IThingQueryService _thingQueryService;
        private readonly IThingCommandService _thingCommandService;
        private readonly ILogger<ThingController> _logger;

        public ThingController(
            IThingQueryService thingQueryService,
            IThingCommandService thingCommandService,
            ILogger<ThingController> logger)
        {
            _thingQueryService = thingQueryService;
            _thingCommandService = thingCommandService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThingListDto>>> GetThings()
        {
            return Ok(await _thingQueryService.GetThings());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThingDto>> GetThing(int id)
        {
            return Ok(await _thingQueryService.GetThing(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateThing(CreateThingDto createThingDto)
        {
            return StatusCode(201, await _thingCommandService.CreateThing(createThingDto));
        }

        // PUT: api/things/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/things/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
