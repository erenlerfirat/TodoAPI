using Business.Abstract;
using Core.Aspects.Log;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        private readonly ILog<CategoryManager> logger;
        public CategoryManager(ICategoryDal categoryDal, ILog<CategoryManager> logger)
        {
            this.categoryDal = categoryDal;
            this.logger = logger;
        }
        
        public async Task<IResult> CreateAsync(Category category)
        {            
            await categoryDal.AddAsync(category);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await categoryDal.DeleteAsync(id);
            return new SuccessResult();
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            var result = await categoryDal.GetByIdAsync(id);
            return new SuccessDataResult<Category>(result);
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            logger.Info("GetAll ");
            Expression<Func<Category, bool>> predicate = p => true;
            var result = await categoryDal.GetAllAsync(predicate);
            return new SuccessDataResult<List<Category>>(result);
        }

        public async Task<IDataResult<Category>> UpdateAsync(Category category)
        {
            var result = await categoryDal.UpdateAsync(category);
            return new SuccessDataResult<Category>(result);
        }
    }
}
