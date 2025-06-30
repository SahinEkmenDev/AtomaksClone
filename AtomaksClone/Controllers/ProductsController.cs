using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AtomaksClone.Data;
using AtomaksClone.Models;
using AtomaksClone.DTOs;
using AtomaksClone.DTOs.AtomaksClone.DTOs;
using AtomaksClone.Services;

namespace AtomaksClone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            return Ok(_mapper.Map<ProductDto>(product));
        }

        // POST: api/products
        [HttpPost("Add")]
        public async Task<ActionResult<ProductDto>> CreateProduct(
     [FromForm] CreateProductDto createProductDto,
     IFormFile image,
     [FromServices] PhotoService photoService)
        {
            var product = _mapper.Map<Product>(createProductDto);
            product.CreatedAt = DateTime.UtcNow;
            product.IsActive = true;

            // Cloudinary upload
            if (image != null)
            {
                var imageUrl = await photoService.UploadPhotoAsync(image);
                product.ImageUrl = imageUrl;
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, productDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(
    int id,
    [FromForm] UpdateProductDto updateProductDto,
    IFormFile image,
    [FromServices] PhotoService photoService)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            _mapper.Map(updateProductDto, product);
            product.UpdatedAt = DateTime.UtcNow;

            // Cloudinary upload
            if (image != null)
            {
                var imageUrl = await photoService.UploadPhotoAsync(image);
                product.ImageUrl = imageUrl;
            }

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ProductDto>(product));
        }


        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
