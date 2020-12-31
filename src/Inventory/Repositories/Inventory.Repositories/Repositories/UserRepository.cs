using Common.Repository;
using Inventory.Data.Entities;
using Inventory.Repositories.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Inventory.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> FindUserByEmail(string email)
        {
            return await DbSet.FirstOrDefaultAsync(t => t.Email == email);
        }
        public async Task<User> GetByGuid(Guid guid)
        {
            return await DbSet
                .FirstOrDefaultAsync(p =>
                    p.Guid == guid);
        }
    }
}