using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDto productDto)
        {
            var username = User.Identity?.Name ?? "Unknown";
            Console.WriteLine($"[Log] Product added by: {username}");

            await _productService.AddAsync(productDto);
            return Ok();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDto productDto)
        {
            var username = User.Identity?.Name ?? "Unknown";
            Console.WriteLine($"[Log] Product updated by: {username}");

            await _productService.UpdateAsync(productDto);
            return NoContent();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            var username = User.Identity?.Name ?? "Unknown";
            Console.WriteLine($"[Log] Product deleted by: {username}");

            await _productService.DeleteAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("crash")]
        public IActionResult Crash()
        {
            throw new Exception("Bir şeyler ters gitti!");
        }
    }
}
