using System;

namespace Inventory.Models.Dtos.Response
{
    public class ThingDto
    {
        public int Id { get; set; }

        public int? PlaceId { get; set; }

        public string Name { get; set; }
        public string PlaceName { get; set; }

        public string Description { get; set; }

        public decimal? Value { get; set; }

        public string CurrencyCode { get; set; }

        public string CategoryName { get; set; }

        public DateTimeOffset LastUpdatedOn { get; set; }
    }
}