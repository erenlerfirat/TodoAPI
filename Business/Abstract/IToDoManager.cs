using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IToDoManager
    {
        IDataResult<Todo> GetById(int id);
        IDataResult<List<Todo>> GetAll();
        IResult Create(Todo todo);
        IDataResult<Todo> Update(Todo todo);
        IResult Delete(int id);
    }
}
