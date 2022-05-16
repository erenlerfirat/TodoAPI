using Core.IEntity;
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

        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                var category = _context.FindAsync<TEntity>(id);
                _context.Remove(category);
                _context.SaveChangesAsync();
            });
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
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
