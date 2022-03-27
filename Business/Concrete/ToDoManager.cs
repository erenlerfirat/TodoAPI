using Business.Abstract;
using Core.Utilities.Results;
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
        

        public IResult Create(Todo todo)
        {
            todoDal.Add(todo);
            return new SuccessResult("h");
        }

        public IResult Delete(int id)
        {
            todoDal.Delete(id);
            return new SuccessResult();
        }

        public IDataResult<Todo> GetById(int id)
        {
           var result = todoDal.Get(id);
           return new SuccessDataResult<Todo>(result);
        }

        public IDataResult<List<Todo>> GetAll()
        {
            Expression<Func<Todo, bool>> predicate = p => true;
            var result = todoDal.GetAll(predicate);
            return new SuccessDataResult<List<Todo>>(result);
        }

        public IDataResult<Todo> Update(Todo todo)
        {   
            var result = todoDal.Update(todo);
            return new SuccessDataResult<Todo>(result);
        }
    }
}
