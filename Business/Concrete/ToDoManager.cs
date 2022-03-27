using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ToDoManager:IToDoManager
    {
        
        private readonly ITodoDal todoDal;
        public ToDoManager(ITodoDal todoDal)
        {
            this.todoDal = todoDal;
        }
        

        public Todo Create(Todo todo)
        {
            todoDal.Add(todo);
            return todo;
        }

        public void Delete(int id)
        {
            todoDal.Delete(id);
        }

        public Todo GetById(int id)
        {  
           return todoDal.Get(id);
        }

        public List<Todo> GetAll()
        {
            Expression<Func<Todo, bool>> predicate = p => true;
            
            return todoDal.GetAll(predicate);
        }

        public Todo Update(Todo todo)
        {
            return todoDal.Update(todo);
        }
    }
}
