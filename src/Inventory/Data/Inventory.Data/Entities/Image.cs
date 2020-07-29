using Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data.Entities
{
    public class Image : IDateTimeEntity
    {
        public Image()
        {
            Things = new HashSet<Thing>();
            ThingLocations = new HashSet<ThingLocation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Path { get; set; }

        [Required]
        [MaxLength(5)]
        public string Format { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedOn { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? UpdatedOn { get; set; }

        public ICollection<Thing> Things { get; set; }
        public ICollection<ThingLocation> ThingLocations { get; set; }

    }
}