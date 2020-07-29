using Common.Repository;
using Inventory.Data.Entities;
using Inventory.Repositories.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Repositories.Repositories
{
    public class ThingRepository : Repository<Thing>, IThingRepository
    {
        public ThingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Thing>> GetAll()
        {
            return await DbSet
                .Where(t => t.Deleted == false)
                .ToListAsync();
        }
    }
}