using Common.Repository.Interfaces;
using Places.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Repositories.Repositories.Intefaces
{
    public interface IPlaceRepository : IRepository<Place>
    {
        Task<IEnumerable<Place>> GetPlaces();
        Task<Place> GetPlaceWithParent(int id);
    }
}