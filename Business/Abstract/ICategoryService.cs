using Core.Utilities.Results;
using Entity.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> GetByIdAsync(int id);
        Task<IDataResult<List<Category>>> GetAllAsync();
        Task<IResult> CreateAsync(Category category);
        Task<IDataResult<Category>> UpdateAsync(Category category);
        Task<IResult> DeleteAsync(int id);
    }
}
