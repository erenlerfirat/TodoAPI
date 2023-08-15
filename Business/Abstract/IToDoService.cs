using Core.Utilities.Results;
using Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IToDoService
    {
        Task<IDataResult<Todo>> GetById(int id);
        Task<IDataResult<List<Todo>>> GetAll();
        Task<IResult> Create(Todo todo);
        Task<IDataResult<Todo>> Update(Todo todo);
        Task<IResult> Delete(int id);
    }
}
