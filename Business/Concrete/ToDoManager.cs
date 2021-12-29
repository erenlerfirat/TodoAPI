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

        public Todo Get(int id)
        {  
           return todoDal.Get(id);
        }

        public List<Todo>  GetAll()
        {
            return todoDal.GetAll();
        }

        public Todo Update(Todo todo)
        {
            return todoDal.Update(todo);
        }
    }
}
