using Inventory.Models.Dtos.Response;
using Inventory.Services.Query.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.WebApi.Controllers
{
    [Authorize]
    [Route("api/places")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceQueryService _placeQueryService;

        public PlaceController(IPlaceQueryService placeQueryService)
        {
            _placeQueryService = placeQueryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PlaceListDto>>> GetPlaces()
        {
            return Ok(await _placeQueryService.GetPlaces());
        }
    }
}