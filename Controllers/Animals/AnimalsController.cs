using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Data;
using PowHome.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowHome.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AnimalsController(MyDbContext context)
        {
            _context = context;
        }

        // Bring them all
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var animals = await _context.Animals.Include(a => a.Specie).Include(a => a.AdoptionCenter).ToListAsync();
            return Ok(animals);
        }

        // Get by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await _context.Animals
                .Include(a => a.Specie)
                .Include(a => a.AdoptionCenter)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

                // Get by Name
        [HttpGet("FindByName/{Name}")]
        public async Task<IActionResult> Get(string name)
        {
            var animal = await _context.Animals.FindAsync(name);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // Create a new animal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        // Update an existing animal
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Animal updatedAnimal)
        {
            if (id != updatedAnimal.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(updatedAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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

