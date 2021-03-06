using Core.Entity;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TContext : DbContext
        where TEntity : class ,IEntity, new()
    {
        private readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var category = (TEntity)_context.FindAsync<TEntity>(id).Result;
            _context.Remove<TEntity>(category);
             await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).SingleOrDefaultAsync();
        }
        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
           return await Task.Run(() => {
                return filter == null
                        ? _context.Set<TEntity>().ToList()
                        : _context.Set<TEntity>().Where(filter).ToList();
            });            
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var category = _context.Entry<TEntity>(entity);
            category.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        
    }
}
