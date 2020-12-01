using Common.Repository.Interfaces;
using Inventory.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Repositories.Repositories.Intefaces
{
    public interface IThingRepository : IRepository<Thing>
    {
        Task<IEnumerable<Thing>> GetWithCategoriesAndCurrenciesAndPlaces(Guid userGuid);
        Task<Thing> GetById(int id, Guid userGuid);
    }
}