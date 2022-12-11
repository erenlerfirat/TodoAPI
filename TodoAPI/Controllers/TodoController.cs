using Business.Abstract;
using Business.Constants;
using Core.Helpers;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/Todo")]
    public class TodoController : ControllerBase
    {
        private readonly IToDoService toDoManager;
        public TodoController(IToDoService toDoManager)
        {
            this.toDoManager = toDoManager;

        }
        [HttpGet("Test")]
        public IActionResult Test()
        {
            var data = AppSettingsHelper.GetValue("SqlServerConnectionString", "");
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // This will get the current PROJECT bin directory (ie ../bin/)
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            // This will get the current PROJECT directory
            string projectDirectory2 = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return Ok(data);
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

        [HttpDelete("Delete{id}")]
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
