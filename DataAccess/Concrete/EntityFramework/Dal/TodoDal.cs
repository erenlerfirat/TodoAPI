using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class TodoDal : EntityRepositoryBase<Todo, TodoContext>,ITodoDal
    {
        public TodoDal(TodoContext context):base(context)
        {

        }
    }
}
