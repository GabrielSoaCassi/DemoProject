using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoDemo.Application.DTOs;
using ProjetoDemo.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null) return NotFound("Categories not Found");
            return Ok(categories);
        }

        [HttpGet("{id:int}",Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound("Category not found");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest("Invalid Data");
            await _categoryService.AddAsync(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new {id = categoryDTO.Id },categoryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();
            if (categoryDto == null) return BadRequest();
            await _categoryService.UpdateAsync(categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound("Category not found.");
            await _categoryService.RemoveAsync(id);
            return Ok(category);
        }
    }
}
