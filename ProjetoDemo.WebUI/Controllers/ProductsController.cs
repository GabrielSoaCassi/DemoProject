using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoDemo.Application.DTOs;
using ProjetoDemo.Application.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjetoDemo.WebUI.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductService productService, ICategoryService categhoryService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _categoryService = categhoryService;
            _environment = environment;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productDto = await _productService.GetByIdAsync(id);
            if (productDto == null) return NotFound();
            var categories = await _categoryService.GetCategoriesAsync();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var produtoDto = await _productService.GetByIdAsync(id.Value);
            if (produtoDto == null) return NotFound();
            return View(produtoDto);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _productService.RemoveAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) return NotFound();
            var productDto = await _productService.GetByIdAsync(id.Value);    
            if (productDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDto.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;
            return View(productDto);
        }
    }
}
