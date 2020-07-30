using System.ComponentModel.DataAnnotations;

namespace Inventory.Models.Dtos.Request.Thing
{
    public class UpdateThingDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public decimal? Value { get; set; }

        public int? CurrencyId { get; set; }

        public int? CategoryId { get; set; }
    }
}