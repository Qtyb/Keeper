using Common.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory.Data.Entities
{
    public class ThingLocation : IGuidEntity, IDateTimeEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Quantity { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedOn { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? UpdatedOn { get; set; }

        public int ThingId { get; set; }
        public Thing Thing { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }

        internal static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ThingLocation>()
                .HasOne(tl => tl.Thing)
                .WithMany(t => t.ThingLocations)
                .HasForeignKey(tl => tl.ThingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ThingLocation>()
                .HasOne(tl => tl.Location)
                .WithMany(t => t.ThingLocations)
                .HasForeignKey(tl => tl.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
