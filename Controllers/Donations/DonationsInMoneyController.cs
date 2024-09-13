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
    public class DonationsInMoneyController : Controller
    {  
        private readonly MyDbContext _context;

        public DonationsInMoneyController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoneyDonations>>> GetMDonations()
        {
            return await _context.MoneyDonations.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MoneyDonations>> PostMDonations([FromBody] MoneyDonations moneyDonations)
        {
            _context.MoneyDonations.Add(moneyDonations);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMDonations), new {id = moneyDonations.Id}, moneyDonations);
        }

        private bool MoneyDonExists(int id)
        {
            return _context.MoneyDonations.Any(p => p.Id == id);
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
                if (!MoneyDonExists(adoptionCenterput.Id))
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