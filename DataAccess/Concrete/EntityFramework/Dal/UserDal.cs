using Core.Entity.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserDal : EntityRepositoryBase<User, TodoContext>, IUserDal
    {
        public UserDal(TodoContext context):base(context)
        {

        }
        public void Add() { }
        
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new TodoContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
        
    }
}
