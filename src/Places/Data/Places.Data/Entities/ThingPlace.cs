using Common.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Places.Data.Entities
{
    public class ThingPlace : IGuidEntity, IDateTimeEntity
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

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public int ThingId { get; set; }
        public Thing Thing { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }

        internal static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ThingPlace>()
                .HasOne(tl => tl.Thing)
                .WithMany(t => t.ThingPlaces)
                .HasForeignKey(tl => tl.ThingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ThingPlace>()
                .HasOne(tl => tl.Place)
                .WithMany(t => t.ThingPlaces)
                .HasForeignKey(tl => tl.PlaceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}