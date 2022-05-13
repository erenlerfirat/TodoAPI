using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CategoryDal : EfEntityRepositoryBase<Category, TodoContext> 
    {
        public CategoryDal(TodoContext context):base(context)
        {

        }        
      
    }
}
