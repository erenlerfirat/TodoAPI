using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CategoryDal : EntityRepositoryBase<Category, TodoContext> , ICategoryDal
    {
        public CategoryDal(TodoContext context):base(context)
        {

        }        
      
    }
}
