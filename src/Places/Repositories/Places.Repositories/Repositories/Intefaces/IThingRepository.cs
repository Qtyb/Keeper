using Common.Repository.Interfaces;
using Places.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Places.Repositories.Repositories.Intefaces
{
    public interface IThingRepository : IRepository<Thing>
    {
        Task<Thing> GetByGuid(Guid guid);
    }
}