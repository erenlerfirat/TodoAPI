using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.Add(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<User>> GetByMail(string email)
        {   var result = await _userDal.Get(u => u.Email == email);
            if (result == null)
               return new ErrorDataResult<User>();
            return  new SuccessDataResult<User>(result); ;
        }
    }
}
