namespace Inventory.Models.Dtos.Response
{
    public class ThingListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Value { get; set; }

        public string CurrencyCode { get; set; }

        public string CategoryName { get; set; }
    }
}