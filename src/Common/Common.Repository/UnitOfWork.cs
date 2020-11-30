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
            var entityEntries = _dbContext.ChangeTracker.Entries();
            HandleNewEntities(entityEntries);
            HandleModifiedEntities(entityEntries);

            await _dbContext.SaveChangesAsync();
        }

        private void HandleNewEntities(IEnumerable<EntityEntry> entityEntries)
        {
            var newEntityEntries = entityEntries.Where(e => e.State == EntityState.Added);

            AddNewGuidToEntities(newEntityEntries);
            AddCreatedTimeToEntities(newEntityEntries);
        }

        private void HandleModifiedEntities(IEnumerable<EntityEntry> entityEntries)
        {
            var modifiedEntityEntries = entityEntries.Where(e => e.State == EntityState.Modified);

            UpdateTimeOnEntities(modifiedEntityEntries);
        }

        private void AddNewGuidToEntities(IEnumerable<EntityEntry> entityEntries)
        {
            foreach (var entityEntry in entityEntries)
            {
                if (entityEntry.Entity is IGuidEntity guidEntity &&
                    guidEntity.Guid == default)
                {
                    guidEntity.Guid = Guid.NewGuid();
                }
            }
        }

        private void AddCreatedTimeToEntities(IEnumerable<EntityEntry> entityEntries)
        {
            foreach (var entityEntry in entityEntries)
            {
                if (entityEntry.Entity is IDateTimeEntity dateTimeEntity)
                {
                    dateTimeEntity.CreatedOn = DateTime.Now;
                }
            }
        }

        private void UpdateTimeOnEntities(IEnumerable<EntityEntry> entityEntries)
        {
            foreach (var entityEntry in entityEntries)
            {
                if (entityEntry.Entity is IDateTimeEntity dateTimeEntity)
                {
                    dateTimeEntity.UpdatedOn = DateTime.Now;
                }
            }
        }
    }
}