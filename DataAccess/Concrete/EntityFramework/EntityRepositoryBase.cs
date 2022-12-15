using Core.Entity;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TContext : DbContext
        where TEntity : class ,IEntity, new()
    {
        private readonly TContext _context;
        private readonly IQueryable _queryable;

        public EntityRepositoryBase(TContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).SingleOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.FindAsync<TEntity>(id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }
        
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
           return await Task.Run(() => {
                return filter == null
                        ? _context.Set<TEntity>().ToList()
                        : _context.Set<TEntity>().Where(filter).ToList();
            });            
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var category = _context.Entry(entity);
            category.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        
    }
}
