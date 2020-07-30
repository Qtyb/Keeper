using Inventory.Models.Dtos.Request.Thing;
using Inventory.Models.Dtos.Response;
using Inventory.Services.Query.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ThingListDto>>> GetThings()
        {
            return Ok(await _thingQueryService.GetThings());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThingDto>> GetThing(int id)
        {
            return Ok(await _thingQueryService.GetThing(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateThing(CreateThingDto createThingDto)
        {
            return StatusCode(201, await _thingCommandService.CreateThing(createThingDto));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Put(int id, UpdateThingDto updateThingDto)
        {
            await _thingCommandService.UpdateThing(id, updateThingDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            await _thingCommandService.DeleteThing(id);
            return NoContent();
        }
    }
}