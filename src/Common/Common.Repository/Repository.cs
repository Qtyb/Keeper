using Common.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        protected DbSet<T> DbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public virtual async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual void Add(T entity)
        {
            _dbContext.Add(entity);
        }
    }
}