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

        public async Task<IResult> CreateAsync(Category category)
        {
            await _categoryDal.Add(category);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _categoryDal.Delete(id);
            return new SuccessResult();
        }

        public async Task<IDataResult<ICollection<Category>>> GetAllAsync()
        {
            var result = await _categoryDal.GetAll();
            return new SuccessDataResult<ICollection<Category>>(result);
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            var result = await _categoryDal.Get(id);
            return new SuccessDataResult<Category>(result);
        }

        public async Task<IDataResult<Category>> UpdateAsync(Category category)
        {
            var result = await _categoryDal.Update(category);
            return new SuccessDataResult<Category>(result);
        }

        
    }
}
