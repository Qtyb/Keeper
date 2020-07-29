using Common.Data.Interfaces;
using Common.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            HandleNewEntities();

            await _dbContext.SaveChangesAsync();
        }

        private void HandleNewEntities()
        {
            var newEntityEntries = _dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added);

            AddNewGuidToEntities(newEntityEntries);
        }

        private void AddNewGuidToEntities(IEnumerable<EntityEntry> entityEntries)
        {
            foreach (var entityEntry in entityEntries)
            {
                if (entityEntry.Entity is IGuidEntity guidEntity)
                {
                    guidEntity.Guid = Guid.NewGuid();
                }
            }
        }
    }
}