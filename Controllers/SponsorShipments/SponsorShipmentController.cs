using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Data;
using PowHome.Models;


namespace PowHome.Controllers.SponsorShipment
{
    [Route("api/v1/[controller]")]
    public class SponsorShipmentController : Controller
    {
        private readonly MyDbContext _context;

        public SponsorShipmentController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sponsorshipment>>> GetSponsorShipment()
        {
            return await _context.Sponsorshipments.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Sponsorshipment>> PostSponsorShipment([FromBody] Sponsorshipment sponsorshipment)
        {

            DateTime currentTime = DateTime.Now;


            if (sponsorshipment.StartDate <= currentTime )
            {
                return BadRequest("The start date canot be more than de end date");
            }else if (sponsorshipment.EndDate <= currentTime)
            {
                return BadRequest(" the end date canot be less than de star date");
            }else
            {
                _context.Sponsorshipments.Add(sponsorshipment);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetSponsorShipment), new { id = sponsorshipment.Id }, sponsorshipment + " succesful");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _context.Sponsorshipments.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Sponsorshipments.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sponsorshipment>> GetSponsorShipmentById([FromRoute] int id)
        {
            var Sponsor = await _context.Sponsorshipments.FindAsync(id);

            if (Sponsor == null)
            {
                return NotFound();
            }

            return Ok(Sponsor);
        }

    }
}
