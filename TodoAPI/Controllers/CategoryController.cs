using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Create(Category category)
        {
            var result = await _categoryService.CreateAsync(category);

            if(result.Success)
                return Ok(Messages.Success);

            return BadRequest(Messages.Error);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();

            if (result.Success)
                return Ok(result.Data);   
            
            return BadRequest(Messages.Error);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if(result.Success)
                return Ok(Messages.Success);

            return BadRequest(Messages.Error);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Category category)
        {
            var result = await _categoryService.UpdateAsync(category);

            if (result.Success)
                return Ok(Messages.Success);

            return BadRequest(Messages.Error);
        }
        
    }
}
