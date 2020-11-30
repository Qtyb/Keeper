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
    public class ThingRepository : Repository<Thing>, IThingRepository
    {
        public ThingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Thing> GetById(int id, Guid userGuid)
        {
            return await DbSet
                .FirstOrDefaultAsync(t =>
                    t.Id == id &&
                    t.User.Guid == userGuid);
        }

        public async Task<IEnumerable<Thing>> GetWithCategoriesAndCurrencies(Guid userGuid)
        {
            return await DbSet
                .Where(t => 
                    t.Deleted == false &&
                    t.User.Guid == userGuid)
                .Include(t => t.Currency)
                .Include(t => t.Category)
                .ToListAsync();
        }
    }
}