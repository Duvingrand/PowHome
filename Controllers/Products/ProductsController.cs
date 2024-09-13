using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Data;
using PowHome.Models;

namespace PowHome.Controllers.Products
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduc()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            if (NameExists(product.Name))
            {
                return BadRequest("El nombre del producto ya está en uso.");              
            }
            
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduc), new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<IActionResult> PutProduc([FromBody] Product productPut)
        {
            if (productPut.Id == 0)
            {
                return BadRequest("Debe ingresar un id existente");
            }

            _context.Entry(productPut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(productPut.Id))
                {
                    return BadRequest("El Id ingresado no es valido.");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return BadRequest("El Id ingresado no es valido.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Get by Name
        [HttpGet("FindByName")]
        public async Task<ActionResult<Product>> GetProduct(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);

            if (product == null)
            {
                return BadRequest("El nombre ingresado no es valido.");
            }

            return Ok(product);
        }

        // Get by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return BadRequest("El Id ingresado no es valido.");
            }

            return Ok(product);
        }

        // verifica que el id no se repita
        private bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }

        // confirma si el nombre ya existe
        private bool NameExists(string name)
        {
            return _context.Products.Any(e => e.Name == name);
        }
    }

}