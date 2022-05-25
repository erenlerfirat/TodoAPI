using Core.Entity.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        Task<IResult> AddAsync(User user);
        Task<IDataResult<User>> GetByMail(string email);
    }
}
