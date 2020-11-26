using Common.Repository;
using Microsoft.EntityFrameworkCore;
using Places.Data.Entities;
using Places.Repositories.Repositories.Intefaces;
using System;
using System.Threading.Tasks;

namespace Places.Repositories.Repositories
{
    public class ThingRepository : Repository<Thing>, IThingRepository
    {
        public ThingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Thing> GetByGuid(Guid guid)
        {
            return await DbSet.FirstOrDefaultAsync(t => t.Guid == guid);
        }
    }
}