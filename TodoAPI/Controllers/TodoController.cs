using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController:ControllerBase
    {

        private readonly IToDoManager toDoManager;
        private readonly ILogger<ToDoManager> logger;


        public TodoController(IToDoManager toDoManager, ILogger<ToDoManager> logger)
        {
            this.toDoManager = toDoManager;
            this.logger = logger;
        }
        [HttpGet("Get")]
        public ToDoResponse ListAll()
        {
            var response = new ToDoResponse();
            try
            {
                response.ToDoList = toDoManager.GetAll();
                response.Message = Messages.Success;
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return response;
            }
        }

        [HttpPost("Post")]
        public string PostTodo([FromBody] Todo todo)
        {
            try
            {
                toDoManager.Create(todo);
                return Messages.Success;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Messages.Error;
            }
            
        }
    }

    public class ToDoResponse
    {
        public string Message { get; set; }

        public List<Todo> ToDoList { get; set; }

        public ToDoResponse()
        {
            ToDoList = new();
            Message = Messages.Error;
        }
    }
}
