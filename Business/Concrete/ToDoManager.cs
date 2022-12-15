﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
    public class ToDoManager : IToDoService
    {

        private readonly ITodoDal todoDal;
        public ToDoManager(ITodoDal todoDal)
        {
            this.todoDal = todoDal;
        }

        [ValidationAspect(typeof(TodoValidator))]
        public async Task<IResult> Create(Todo todo)
        {
            ValidationTool.Validate(new TodoValidator(), todo);
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
