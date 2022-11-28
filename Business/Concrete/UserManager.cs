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

        public async Task<IResult> AddAsync(User user)
        {
            var result = await _userDal.AddAsync(user);

            if(result is not null)
             return new SuccessResult("Success");

            return new ErrorResult("Error");
        }

        public Task<IResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<User>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetByIdAync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetByMailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
