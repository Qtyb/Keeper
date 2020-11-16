using System;

namespace Places.Models.Dtos.Response
{
    public class PlaceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentPlaceId { get; set; }
        public string ParentPlaceName { get; set; }
    }
}