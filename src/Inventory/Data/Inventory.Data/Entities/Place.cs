using Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data.Entities
{
    public class Place : IGuidEntity, IDateTimeEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public Guid Guid { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Street { get; set; }

        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public int? ParentLocationId { get; set; }
        public Place ParentLocation { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<ThingPlace> ThingPlaces { get; set; }
    }
}