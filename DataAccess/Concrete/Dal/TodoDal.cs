using DataAccess.Abstract;
using Entity.Domain;

namespace DataAccess.Concrete.Dal
{
    public class TodoDal : EntityRepositoryBase<Todo, TodoContext>, ITodoDal
    {
        public TodoDal(TodoContext context) : base(context)
        {

        }
    }
}
