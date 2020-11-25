using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Places.Models.Dtos.Request;
using Places.Models.Dtos.Response;
using Places.Services.Query.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Places.WebApi.Controllers
{
    //[Authorize]
    [Route("api/places")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceQueryService _placeQueryService;
        private readonly IPlaceCommandService _placeCommandService;
        private readonly ILogger<PlacesController> _logger;

        public PlacesController(
            IPlaceQueryService placeQueryService,
            IPlaceCommandService placeCommandService,
            ILogger<PlacesController> logger)
        {
            _placeQueryService = placeQueryService;
            _placeCommandService = placeCommandService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PlaceListDto>>> GetPlaces()
        {
            return Ok(await _placeQueryService.GetPlaces());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PlaceDto>> GetPlace(int id)
        {
            return Ok(await _placeQueryService.GetPlace(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreatePlace(CreatePlaceDto createPlaceDto)
        {
            return StatusCode(201, await _placeCommandService.CreatePlace(createPlaceDto));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Put(int id, UpdatePlaceDto updatePlaceDto)
        {
            await _placeCommandService.UpdatePlace(id, updatePlaceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            await _placeCommandService.DeletePlace(id);
            return NoContent();
        }
    }
}