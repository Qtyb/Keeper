using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        Task<T> GetById(long id);

        Task<IEnumerable<T>> GetAll();

        void Delete(T entity);

        void Add(T entity);
    }
}