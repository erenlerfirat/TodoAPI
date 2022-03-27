﻿using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/Todo")]
    public class TodoController : ControllerBase
    {

        private readonly IToDoManager toDoManager;
        private readonly ILogger<ToDoManager> logger;


        public TodoController(IToDoManager toDoManager, ILogger<ToDoManager> logger)
        {
            this.toDoManager = toDoManager;
            this.logger = logger;
        }
        [HttpGet("GetAll")]
        public ToDoResponse ListAll()
        {
            var response = new ToDoResponse();
            try
            {
                response.ToDoList = toDoManager.GetAll().Data;
                response.Message = Messages.Success;
                logger.LogInformation($"Result message is :{0}",response.Message);
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return response;
            }
        }
        [HttpGet("GetById")]
        public ToDoResponse Get(int id)
        {
            var response = new ToDoResponse();
            try
            {
                response.SingleTask = toDoManager.GetById(id).Data;
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

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                toDoManager.Delete(id);
            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message);
            }
        }
        [HttpPut]
        public string Update([FromBody] Todo todo)
        {
            try
            {
                toDoManager.Update(todo);
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
        public Todo SingleTask { get; set; }

        public ToDoResponse()
        {
            Message = Messages.Error;
        }
    }
}
