using Common.Repository;
using Inventory.Data.Entities;
using Inventory.Repositories.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Place> GetByGuid(Guid guid)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.Guid == guid);
        }
    }
}