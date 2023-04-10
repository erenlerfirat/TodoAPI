using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Log;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ToDoManager : IToDoService
    {

        private readonly ITodoDal todoDal;
        private readonly ILog<ToDoManager> logger;
        public ToDoManager(ITodoDal todoDal,ILog<ToDoManager> logger)
        {
            this.todoDal = todoDal;
            this.logger = logger;
        }

        [ValidationAspect(typeof(TodoValidator))] // TODO : To be tested
        public async Task<IResult> Create(Todo todo)
        {            
            await todoDal.AddAsync(todo);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(int id)
        {
            await todoDal.DeleteAsync(id);
            return new SuccessResult();
        }

        public async Task<IDataResult<Todo>> GetById(int id)
        {
            var result = await todoDal.GetByIdAsync(id);
            return new SuccessDataResult<Todo>(result);
        }

        public async Task<IDataResult<List<Todo>>> GetAll()
        {
            logger.Info("GetAll");
            var result = await todoDal.GetAllAsync();
            return new SuccessDataResult<List<Todo>>(result);
        }

        public async Task<IDataResult<Todo>> Update(Todo todo)
        {
            var result = await todoDal.UpdateAsync(todo);
            return new SuccessDataResult<Todo>(result);
        }
    }
}
