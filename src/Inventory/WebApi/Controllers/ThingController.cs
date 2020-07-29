using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data.Entities;
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
        private readonly ILogger<ThingController> _logger;

        public ThingController(
            IThingQueryService thingQueryService,
            ILogger<ThingController> logger)
        {
            _thingQueryService = thingQueryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThingListDto>>> GetThings()
        {
            return Ok(await _thingQueryService.GetThings());
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ThingDto>> Get(int id)
        {
            return Ok(await _thingQueryService.GetThing(id));
        }

        // POST: api/things
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
