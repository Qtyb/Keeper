using Places.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Places.Data
{
    public class PlacesContext : DbContext
    {
        public PlacesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Place> Locations { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<ThingPlaces> ThingLocations { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ThingPlaces.OnModelCreating(modelBuilder);
        }
    }
}