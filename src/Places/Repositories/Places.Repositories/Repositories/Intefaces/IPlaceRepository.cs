using Common.Repository.Interfaces;
using Places.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Repositories.Repositories.Intefaces
{
    public interface IPlaceRepository : IRepository<Place>
    {
        Task<IEnumerable<Place>> GetPlaces(Guid userGuid);
        Task<Place> GetPlaceWithParent(int id, Guid userGuid);
        Task<Place> GetById(int id, Guid userGuid);
    }
}