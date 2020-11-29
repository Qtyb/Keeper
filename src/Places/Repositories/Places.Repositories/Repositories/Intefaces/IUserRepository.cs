using Common.Repository.Interfaces;
using Places.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Places.Repositories.Repositories.Intefaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByGuid(Guid guid);
    }
}