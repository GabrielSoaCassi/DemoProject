using AutoMapper;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductss()
        {
            var products = await _productService.GetProductsAsync();
            if (products == null) return NotFound("Products not Found");
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<CategoryDTO>> GetProductById(int id)
        {
            var products = await _productService.GetByIdAsync(id);
            if (products == null) return NotFound("Product not found");
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO productDto)
        {
            if (productDto == null) return BadRequest("Invalid Data.");
            await _productService.AddAsync(productDto);
            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id) return BadRequest("Id Invalid.");
            if (productDto == null) return BadRequest("Data Invalid.");
            await _productService.UpdateAsync(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {

            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound("Product not found.");
            await _productService.RemoveAsync(id);
            return Ok(product);
        }

    }
}
