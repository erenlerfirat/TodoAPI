using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IResult> CreateAsync(Category todo)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ICollection<Category>>> GetAllAsync()
        {
            var result = await _categoryDal.GetAll();
            return new SuccessDataResult<ICollection<Category>>(result);
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Category>> UpdateAsync(Category todo)
        {
            throw new NotImplementedException();
        }

        
    }
}
