using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Data;
using PowHome.Models;

namespace PowHome.Controllers.Donations
{
    [Route("api/v1/[controller]")]

    public class DonationsController : Controller
    {
        private readonly MyDbContext _context;

        public DonationsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donation>>> GetProduc()
        {
            return await _context.Donations.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduc), new {id = product.Id}, product);
        }

    }
}