using Common.Repository.Interfaces;
using Inventory.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Inventory.Repositories.Repositories.Intefaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByGuid(Guid guid);
    }
}