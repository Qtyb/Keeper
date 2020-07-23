using Common.Repository;
using Inventory.Data.Entities;
using Inventory.Repositories.Query.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories.Query
{
    public class ThingQueryRepository : Repository<Thing>, IThingQueryRepository
    {
        public ThingQueryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}