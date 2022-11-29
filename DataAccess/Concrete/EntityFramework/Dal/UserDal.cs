using Core.Entity.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserDal : EntityRepositoryBase<User, TodoContext>, IUserDal
    {
        public UserDal(TodoContext context):base(context)
        {

        }
                
    }
}
