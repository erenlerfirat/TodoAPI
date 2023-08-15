using DataAccess.Abstract;
using Entity.Domain;

namespace DataAccess.Concrete.Dal
{
    public class CategoryDal : EntityRepositoryBase<Category, TodoContext>, ICategoryDal
    {
        public CategoryDal(TodoContext context) : base(context)
        {

        }

    }
}
