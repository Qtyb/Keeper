using Common.Repository;
using Inventory.Data.Entities;
using Inventory.Repositories.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories.Repositories
{
    public class ThingRepository : Repository<Thing>, IThingRepository
    {
        public ThingRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}