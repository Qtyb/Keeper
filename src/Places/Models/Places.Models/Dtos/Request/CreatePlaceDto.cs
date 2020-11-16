using System.ComponentModel.DataAnnotations;

namespace Places.Models.Dtos.Request
{
    public class CreatePlaceDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int? ParentPlaceId { get; set; }
    }
}