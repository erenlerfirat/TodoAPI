using Business.Abstract;
using Core.Entity.Concrete;
using Core.Helpers;
using Entity.Domain;
using Entity.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await userService.GetAllAsync();
            if(!result.Success)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await userService.GetByIdAync(id);
            if (!result.Success)
                return NotFound();
            return Ok(result);
        }
        [HttpPost("Auth")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var result = await userService.Authenticate(request);
            
            return Ok(result);
        }

        [HttpPut("Add")]
        public async Task<IActionResult> Add(UserForRegisterDto userDto)
        {
            HashHelper.Hash(userDto.Password,out string passwordHash);

            var user = new User { Email = userDto.Email ,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                MiddleName= userDto.MiddleName,
                PasswordHash = passwordHash,
            };            
            var result = await userService.AddAsync(user);

            if (!result.Success)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(User user)
        {
            var result = await userService.UpdateAsync(user);
            if (!result.Success)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userService.DeleteAsync(id);
            if (!result.Success)
                return NotFound();
            return Ok(result);
        }
    }
}
