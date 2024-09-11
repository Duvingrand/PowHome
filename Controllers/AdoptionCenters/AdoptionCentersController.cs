using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Data;
using PowHome.Models;


namespace PowHome.Controllers.AdoptionCenters
{
    [Route("api/v1/[controller]")]
    public class AdoptionCenterController : Controller
    {
        private readonly MyDbContext _context;

        public AdoptionCenterController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdoptionCenter>>> GetAdoptionCenter()
        {
            return await _context.AdoptionCenters.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<AdoptionCenter>> PostAdoptionCenter([FromBody] AdoptionCenter adoptionCenter)
        {
            _context.AdoptionCenters.Add(adoptionCenter);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAdoptionCenter), new {id = adoptionCenter.Id}, adoptionCenter);
        }

        

    }
}