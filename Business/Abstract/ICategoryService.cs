using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICategoryService
    {
        Task<IDataResult<Category>> GetByIdAsync(int id);
        Task<IDataResult<ICollection<Category>>> GetAllAsync();
        Task<IResult> CreateAsync(Category todo);
        Task<IDataResult<Category>> UpdateAsync(Category todo);
        Task<IResult> DeleteAsync(int id);
    }
}
