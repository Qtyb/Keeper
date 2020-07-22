using Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data.Entities
{
    public class Thing : IGuidEntity, IDateTimeEntity
    {
        public Thing()
        {
            ThingLocations = new HashSet<ThingLocation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Value { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedOn { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? UpdatedOn { get; set; }

        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ThingLocation> ThingLocations { get; set; }
    }
}