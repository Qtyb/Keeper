using Common.Service.Interfaces;
using Inventory.Models.Dtos.Response;
using Inventory.Repositories.Repositories.Intefaces;
using Inventory.Services.Query.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Services.Query
{
    public class PlaceQueryService : IPlaceQueryService
    {
        private readonly IHttpContextUserService _httpContextUserService;
        private readonly IPlaceRepository _placeRepository;

        public PlaceQueryService(
            IHttpContextUserService httpContextUserService,
            IPlaceRepository placeRepository
            )
        {
            _httpContextUserService = httpContextUserService;
            _placeRepository = placeRepository;
        }

        public async Task<IEnumerable<PlaceListDto>> GetPlaces()
        {
            var userGuid = _httpContextUserService.GetUserGuid();
            var places = await _placeRepository.GetPlaces(userGuid);

            //TODO MOVE TO MAPPING: its 1:57
            var placeListDtos = new List<PlaceListDto>();
            foreach (var place in places)
            {
                placeListDtos.Add(new PlaceListDto { Id = place.Id, Name = place.Name });
            }

            return placeListDtos;
        }
    }
}