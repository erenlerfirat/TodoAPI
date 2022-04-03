using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class TodoDal : ITodoDal
    {
        private readonly TodoContext context;
        public TodoDal(TodoContext context)
        {
            this.context = context;
        }
        public async Task<Todo> Add(Todo entity )
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
            return entity;
        }

        public Task Delete(int id)
        { 
           return Task.Run(()=> {
            var entityToDelete = context.Todos.FindAsync(id);
            context.Remove(entityToDelete);
            context.SaveChangesAsync();
            });
            
        }

        public async Task<Todo> Get(int id)
        {
            return await context.Todos.FindAsync(id);
        }

        public async Task<List<Todo>> GetAll(Expression<Func<Todo, bool>> filter = null)
        {
                return filter == null
                    ? await context.Set<Todo>().ToListAsync()
                    : await context.Set<Todo>().Where(filter).ToListAsync();
        }

        public async Task<Todo> Update(Todo entity)
        {
            var entityToUpdate = context.Entry(entity);
            entityToUpdate.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
