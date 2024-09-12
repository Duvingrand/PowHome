using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Data;
using PowHome.Models;

namespace PowHome.Controllers.Donations
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DonationsInFoodController : Controller
    {  
        private readonly MyDbContext _context;

        public DonationsInFoodController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDonations>>> GetFDonations()
        {
            return await _context.FoodDonations.ToListAsync();
        }

                [HttpPost]
        public async Task<ActionResult<FoodDonations>> PostFDonations([FromBody] FoodDonations foodDonations)
        {
            _context.FoodDonations.Add(foodDonations);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFDonations), new {id = foodDonations.Id}, foodDonations);
        }

        private bool FoodDonExists(int id)
        {
            return _context.FoodDonations.Any(p => p.Id == id);
        }



                private bool AdoptionCenterExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }



        private bool FoodDonationExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }

        [HttpPut]
        public async Task<IActionResult> PutFoodDonation([FromBody] FoodDonations foodDonationsput)
        {
            if (foodDonationsput.Id == 0)
            {
                return BadRequest("Debe ingresar un id existente");
            }
            
            _context.Entry(foodDonationsput).State = EntityState.Modified; 
                
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionCenterExists(foodDonationsput.Id))
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
            var product = await _context.FoodDonations.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.FoodDonations.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AdoptionCenter>> GetAdoptionCenter([FromRoute] int id)
        {
            var foodDonations = await _context.FoodDonations.FindAsync(id);

            if (foodDonations == null)
            {
                return NotFound();
            }

            return Ok(foodDonations);
        }

        
    }
}