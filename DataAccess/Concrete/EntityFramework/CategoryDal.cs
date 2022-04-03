using Core.Utilities.Results;
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
    public class CategoryDal : ICategoryDal
    {
        private readonly TodoContext context;

        public CategoryDal(TodoContext context)
        {
            this.context = context;
        }
        public async Task<Category> Add(Category entity)
        {   
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task Delete(int id)
        {
            return Task.Run(() => {
             var category = context.FindAsync<Category>(id);
             context.Remove(category);
             context.SaveChangesAsync();
            });                        
        }

        public async Task<Category> Get(int id)
        {
            return await context.FindAsync<Category>(id);
        }

        public async Task<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null
                ? context.Set<Category>().ToList()
                : context.Set<Category>().Where(filter).ToList();         
        }

        public async Task<Category> Update(Category entity)
        {
            var category = context.Entry<Category>(entity);
            category.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

      
    }
}
