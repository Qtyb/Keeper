namespace Places.Models.Dtos.Response
{
    public class PlaceListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentPlaceId { get; set; }
        public string ParentPlaceName { get; set; }
    }
}