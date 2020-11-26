using Common.Repository.Interfaces;
using Inventory.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Repositories.Repositories.Intefaces
{
    public interface IPlaceRepository : IRepository<Place>
    {
        Task<Place> GetByGuid(Guid guid);
    }
}