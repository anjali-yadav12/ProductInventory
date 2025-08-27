using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Data;
using Product_Inventory.Models;
using Product_Inventory.DTOs;

namespace Product_Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET all products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    Description = p.Description,
                    Category = p.Category
                })
                .ToListAsync();

            return Ok(products);
        }

        // ✅ GET product by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Description = product.Description,
                Category = product.Category
            };
        }

        // ✅ POST: Create product
        [HttpPost]
        public async Task<ActionResult<Products>> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Products
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                Category = productDto.Category
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // ✅ PUT: Update product details
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.StockQuantity = productDto.StockQuantity;
            product.Description = productDto.Description;
            product.Category = productDto.Category;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: Hard delete product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ GET: Low stock alert (stock < 5)
        [HttpGet("lowstock")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetLowStockProducts()
        {
            var lowStockProducts = await _context.Products
                .Where(p => p.StockQuantity < 5)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    Description = p.Description,
                    Category = p.Category
                })
                .ToListAsync();

            return Ok(lowStockProducts);
        }
    }
}
