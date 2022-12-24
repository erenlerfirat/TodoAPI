using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.Dal
{
    public class TodoDetailDal : EntityRepositoryBase<TodoDetail, TodoContext>, ITodoDetailDal
    {
        public TodoDetailDal(TodoContext context) : base(context)
        {

        }
    }
}
