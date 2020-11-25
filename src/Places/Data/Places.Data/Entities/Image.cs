using Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Places.Data.Entities
{
    public class Image : IDateTimeEntity
    {
        public Image()
        {
            Things = new HashSet<Thing>();
            ThingPlaces = new HashSet<ThingPlace>();
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

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public ICollection<Thing> Things { get; set; }
        public ICollection<ThingPlace> ThingPlaces { get; set; }

    }
}