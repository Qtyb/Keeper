using Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Places.Data.Entities
{
    public class Thing : IGuidEntity, IDateTimeEntity
    {
        public Thing()
        {
            ThingPlaces = new HashSet<ThingPlace>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public Guid Guid { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Value { get; set; }

        public bool Deleted { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<ThingPlace> ThingPlaces { get; set; }
    }
}