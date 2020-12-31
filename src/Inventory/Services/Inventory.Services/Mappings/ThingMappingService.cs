using Inventory.Data.Entities;
using Inventory.Models.Dtos.Request.Thing;
using Inventory.Models.Dtos.Response;
using Inventory.Models.Events.Things;
using Inventory.Services.Mappings.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services.Mappings
{
    public class ThingMappingService : IThingMappingService
    {
        public ThingDto MapToThingDto(Thing thing)
        {
            return new ThingDto()
            {
                Id = thing.Id,
                PlaceId = thing.PlaceId,
                Name = thing.Name,
                Description = thing.Description,
                Value = thing.Value,
                LastUpdatedOn = thing.UpdatedOn ?? thing.CreatedOn
            };
        }

        public IEnumerable<ThingListDto> Map(IEnumerable<Thing> thing)
        {
            return thing.Select(thingElement => new ThingListDto()
            {
                Id = thingElement.Id,
                Name = thingElement.Name,
                PlaceName = thingElement.Place?.Name,
                Value = thingElement.Value
            }).ToList();
        }

        public Thing Map(CreateThingDto createThingDto, int userId)
        {
            return new Thing()
            {
                Name = createThingDto.Name,
                Description = createThingDto.Description,
                Value = createThingDto.Value,
                CurrencyId = createThingDto.CurrencyId,
                CategoryId = createThingDto.CategoryId,
                UserId = userId,
                PlaceId = createThingDto.PlaceId
            };
        }

        public void Map(UpdateThingDto updateThingDto, Thing thing)
        {
            thing.Name = string.IsNullOrEmpty(updateThingDto.Name) ? thing.Name : updateThingDto.Name;
            thing.Description = string.IsNullOrEmpty(updateThingDto.Description) ? thing.Description : updateThingDto.Description;
            thing.Value = updateThingDto.Value ?? thing.Value;
            thing.CurrencyId = updateThingDto.CurrencyId ?? thing.CurrencyId;
            thing.CategoryId = updateThingDto.CategoryId ?? thing.CategoryId;
            thing.PlaceId = updateThingDto.PlaceId ?? thing.PlaceId;
        }

        public ThingCreatedEvent MapToThingCreatedEvent(Thing thing)
        {
            return new ThingCreatedEvent
            {
                Guid = thing.Guid,
                Name = thing.Name,
                Value = thing.Value,
            };
        }

        public ThingUpdatedEvent MapToThingUpdatedEvent(Thing thing)
        {
            return new ThingUpdatedEvent
            {
                Guid = thing.Guid,
                Name = thing.Name,
                Value = thing.Value
            };
        }

        public ThingDeletedEvent MapToThingDeletedEvent(Thing plathingce)
        {
            return new ThingDeletedEvent
            {
                Guid = plathingce.Guid
            };
        }
    }
}