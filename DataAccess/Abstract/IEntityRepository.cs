using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T :class,IEntity,new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
