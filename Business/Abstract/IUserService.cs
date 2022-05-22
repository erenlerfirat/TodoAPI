using Core.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        Task<User> GetByMail(string email);
    }
}
