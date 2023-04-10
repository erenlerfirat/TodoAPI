using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Aspects.Log;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILog<CategoryController> logger;
        public CategoryController(ICategoryService categoryService, ILog<CategoryController> logger)
        {
            _categoryService = categoryService;
            this.logger = logger;
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
            logger.Info("GetAll");
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
