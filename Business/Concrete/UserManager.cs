using Business.Abstract;
using Core.Constants;
using Core.Entity.Concrete;
using Core.Helpers;
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

        public async Task<IDataResult<AuthenticateResponse>> Authenticate(AuthenticateRequest request)
        {
            var user = await _userDal.SingleOrDefaultAsync(x => x.UserName == request.Username);

            bool isPasswordValid = HashHelper.Verify(request.Password,user.PasswordHash);
                        
            if (!isPasswordValid) return new ErrorDataResult<AuthenticateResponse>(Messages.Error);

            var token = TokenHelper.GenerateJwtToken(user);

            return new SuccessDataResult<AuthenticateResponse>(new AuthenticateResponse(user, token));
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _userDal.DeleteAsync(id);
            return new SuccessResult(Messages.Success);
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<User>>> GetAllAsync()
        {
            var result = await _userDal.GetAllAsync();
            return new SuccessDataResult<List<User>> (result);
        }
        public async Task<IDataResult<User>> GetByIdAync(int id)
        {
            var result = await _userDal.GetByIdAsync(id);
            return new SuccessDataResult<User>(result);
        }

        public Task<IDataResult<User>> GetByMailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            var result = await _userDal.UpdateAsync(user);
            return new SuccessDataResult<User>(result);
        }
    }
}
