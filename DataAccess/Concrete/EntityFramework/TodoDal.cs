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
        public Todo Add(Todo entity )
        {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var entityToDelete = context.Todos.Find(id);
            context.Remove(entityToDelete);
            context.SaveChangesAsync();
        }

        public Todo Get(int id)
        {
            return context.Todos.Find(id);
        }

        public List<Todo> GetAll(Expression<Func<Todo, bool>> filter = null)
        {
                return filter == null
                    ? context.Set<Todo>().ToList()
                    : context.Set<Todo>().Where(filter).ToList();
        }

        public Todo Update(Todo entity)
        {
            var entityToUpdate = context.Entry(entity);
            entityToUpdate.State = EntityState.Modified;
            context.SaveChangesAsync();
            return entity;
        }
    }
}
