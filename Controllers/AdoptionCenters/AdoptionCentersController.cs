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
            var AdoptionCenterfind = await _context.AdoptionCenters.FirstOrDefaultAsync(u => u.Name == adoptionCenter.Name);

            if (AdoptionCenterfind == null) // Asegúrate de que la función VerifyPassword compare las contraseñas correctamente
            {
                _context.AdoptionCenters.Add(adoptionCenter);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAdoptionCenter), new { id = adoptionCenter.Id }, adoptionCenter + "succesful");
            }
            else if (AdoptionCenterfind == adoptionCenter)
            {
                return BadRequest("Usuario ya exite");
            }

            return Ok(  "Already exist");
        }



        private bool AdoptionCenterExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }


                [HttpPut]
        public async Task<IActionResult> PutAdoptionCenter([FromBody] AdoptionCenter adoptionCenterput)
        {
            if (adoptionCenterput.Id == 0)
            {
                return BadRequest("Debe ingresar un id existente");
            }
            
            _context.Entry(adoptionCenterput).State = EntityState.Modified; 
                
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionCenterExists(adoptionCenterput.Id))
                {
                    return NotFound();
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
            var product = await _context.AdoptionCenters.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.AdoptionCenters.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AdoptionCenter>> GetAdoptionCenter([FromRoute] int id)
        {
            var AdoptionCenter = await _context.AdoptionCenters.FindAsync(id);

            if (AdoptionCenter == null)
            {
                return NotFound();
            }

            return Ok(AdoptionCenter);
        }

        

    }
}