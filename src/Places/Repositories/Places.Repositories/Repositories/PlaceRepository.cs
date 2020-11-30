using Common.Repository;
using Inventory.Repositories.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using Places.Data.Entities;
using System;
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

        public async Task<Place> GetById(int id, Guid userGuid)
        {
            return await DbSet
                .FirstOrDefaultAsync(p =>
                    p.Id == id &&
                    p.User.Guid == userGuid);
        }

        public async Task<IEnumerable<Place>> GetPlaces(Guid userGuid)
        {
            return await DbSet
                .Where(p => 
                    p.Deleted == false &&
                    p.User.Guid == userGuid)
                .ToListAsync();
        }

        public async Task<Place> GetPlaceWithParent(int id, Guid userGuid) => 
            await DbSet
                .Include(p => p.ParentPlace)    
                .FirstOrDefaultAsync(p => 
                    p.Id == id && 
                    p.Deleted == false &&
                    p.User.Guid == userGuid);
    }
}