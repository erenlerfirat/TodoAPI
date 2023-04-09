using Business.Abstract;
using Business.Constants;
using Core.Aspects.Log;
using Core.Attributes.JWT;
using Core.Constants;
using Core.Extensions;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IToDoService toDoManager;
        private readonly ILog logger;
        public TodoController(IToDoService toDoManager , ILog logger)
        {
            this.toDoManager = toDoManager;
            this.logger = logger;

        }
        [Authorize]
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("TestMethod".Truncate(5));
        }
        [HttpGet("HtmlContent")]
        public ContentResult Html()
        {
            logger.Warn("test log ------ ");

            string html = Template.Html;
            var result = base.Content(html, "text/html");
            return result;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await toDoManager.GetAll();
            if (!result.Success)
                return BadRequest(Messages.Error);
            return Ok(result.Data);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await toDoManager.GetById(id);
            if (!result.Success)
                return BadRequest(Messages.Error);
            return Ok(result.Data);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> PostTodo([FromBody] Todo todo)
        {
            var result = await toDoManager.Create(todo);
            if (!result.Success)
                return BadRequest(Messages.Error);
            return Ok(Messages.Success);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await toDoManager.Delete(id);
            if (!result.Success)
                return BadRequest(Messages.Error);
            return Ok(Messages.Success);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Todo todo)
        {
            var result = await toDoManager.Update(todo);
            if (!result.Success)
                return BadRequest(Messages.Error);
            return Ok(result.Data);
        }
    }


}
