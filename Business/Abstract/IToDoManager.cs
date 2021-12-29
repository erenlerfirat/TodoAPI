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
        Todo Get(Expression<Func<Todo, bool>> filter);
        List<Todo> GetAll();
        Todo Create(Todo todo);
        Todo Update(Todo todo);
        void Delete(int id);
    }
}
