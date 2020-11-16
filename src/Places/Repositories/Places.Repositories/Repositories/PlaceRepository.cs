using Common.Repository;
using Inventory.Repositories.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using Places.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Repositories.Repositories
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            return await DbSet
                .Where(p => p.Deleted == false)
                .ToListAsync();
        }

        public async Task<Place> GetPlaceWithParent(int id) => 
            await DbSet
                .Include(p => p.ParentPlace)    
                .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);
    }
}