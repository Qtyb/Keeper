using Common.Repository;
using Microsoft.EntityFrameworkCore;
using Places.Data.Entities;
using Places.Repositories.Repositories.Intefaces;
using System;
using System.Threading.Tasks;

namespace Places.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByGuid(Guid guid)
        {
            return await DbSet
                .FirstOrDefaultAsync(p =>
                    p.Guid == guid);
        }
    }
}