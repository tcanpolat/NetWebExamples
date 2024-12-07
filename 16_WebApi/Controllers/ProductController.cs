using _16_WebApi.DataContext;
using _16_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _16_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // Get : api/Products/GetProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if(_context.Products.Count() > 0)
            {
                return await _context.Products.ToListAsync();
            }

            return NotFound();
        }

        // Get : api/Products/GetProduct/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            return product;

        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT : api/Products/PutProducts
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if(id != product.Id)
            {
                return NoContent();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;

                }

            }

            return Ok();

        }


        // Delete : api/Products/DeleteProduct/id

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
