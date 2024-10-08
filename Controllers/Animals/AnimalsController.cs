using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Data;
using PowHome.Models; 

namespace PowHome.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : Controller
    {
        private readonly MyDbContext _context;

        public AnimalsController(MyDbContext context)
        {
            _context = context;
        }

        // Bring them all
        [HttpGet]
         public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal()
        {
            // var animals = await _context.Animals.Include(a => a.Specie).Include(a => a.AdoptionCenter).ToListAsync();
            // return Ok(animals);
            return await _context.Animals.ToListAsync();
        }

        // Get by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await _context.Animals
                .Include(a => a.AdoptionCenter)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // Get by Name
        [HttpGet("FindByName/Name")]
        public async Task<ActionResult<Animal>> Get(string name)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(p => p.Name == name);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // Create a new animal
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // animal.BirthDate 
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        // Update an existing animal
        [HttpPut]
        public async Task<IActionResult> Put(Animal updatedAnimal)
        {
            if (updatedAnimal.Id == 0)
            {
                return BadRequest("No Existe");
            }

            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }

            _context.Entry(updatedAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(updatedAnimal.Id))
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

        // Delete an animal
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _context.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }
    }
}

