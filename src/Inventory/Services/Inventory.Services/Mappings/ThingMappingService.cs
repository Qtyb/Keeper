using Inventory.Data.Entities;
using Inventory.Models.Dtos.Response;
using Inventory.Services.Mappings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.Services.Mappings
{
    public class ThingMappingService : IThingMappingService
    {
        public ThingDto Map(Thing thing)
        {
            return new ThingDto()
            {
                Id = thing.Id,
                Name = thing.Name,
                Description = thing.Description,
                Value = thing.Value,
                CurrencyCode = thing.Currency?.Code,
                CategoryName = thing.Category?.Name,
                LastUpdatedOn = thing.UpdatedOn ?? thing.CreatedOn
            };
        }

        public IEnumerable<ThingListDto> Map(IEnumerable<Thing> thing)
        {
            return thing.Select(thingElement => new ThingListDto()
            {
                Id = thingElement.Id,
                Name = thingElement.Name,
                Value = thingElement.Value,
                CurrencyCode = thingElement.Currency?.Code,
                CategoryName = thingElement.Category?.Name
            }).ToList();
        }
    }
}
