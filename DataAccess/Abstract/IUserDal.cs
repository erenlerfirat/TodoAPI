using Core.Entity.Concrete;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
