using Inventory.Data.Entities;
using Inventory.Models.Dtos.Response;
using Inventory.Services.Mappings.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Services.Mappings
{
    public class ThingMappingService : IThingMappingService
    {
        public ThingListDto Map(Thing thing)
        {
            return new ThingListDto()
            {
                Id = thing.Id,
                Name = thing.Name,
                Value = thing.Value,
                CurrencyCode = thing?.Currency?.Code,
                CategoryName = thing?.Category?.Name
            };
        }
    }
}
