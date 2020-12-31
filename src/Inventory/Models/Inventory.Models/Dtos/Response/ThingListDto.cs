namespace Inventory.Models.Dtos.Response
{
    public class ThingListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string PlaceName { get; set; }

        public decimal? Value { get; set; }
    }
}