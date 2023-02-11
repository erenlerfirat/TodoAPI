using Core.Entity.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> GetByMailAsync(string email); 
        Task<IResult> AddAsync(User user);
        Task<IResult> UpdateAsync(User user);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<User>> GetByIdAync(int id);
        Task<IDataResult<List<User>>> GetAllAsync();
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        IEnumerable<User> GetAll();
    }
}
