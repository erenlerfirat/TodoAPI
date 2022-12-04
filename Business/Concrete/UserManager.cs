using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
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

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userDal.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public Task<IResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<User>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
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
