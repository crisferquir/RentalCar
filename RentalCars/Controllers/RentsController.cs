using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalCars.Data;
using RentalCars.Models;
using RentalCars.Business;


namespace RentalCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly RentalCarsContext _context;

        public RentsController(RentalCarsContext context)
        {
            _context = context;
        }

        // GET: api/Rents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent>>> GetRents()
        {
            return await _context.Rents.ToListAsync();
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRents(int id)
        {
            var rents = await _context.Rents.FindAsync(id);

            if (rents == null)
            {
                return NotFound();
            }

            return rents;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRents(int id, Rent rents)
        {
            if (id != rents.Id)
            {
                return BadRequest();
            }

            _context.Entry(rents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentsExists(id))
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

        // POST: api/Rents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rent>> PostRents(Rent rents)
        {

            var typeCar = _context.Cars.Where(c => c.ID == rents.CarID).FirstOrDefault().TypeCar;
            var clientRent = _context.Clients.Find(rents.ClientID);
            var clientPoints = LoyaltyPoints.CalculatePoints(typeCar);
            clientRent.Point += clientPoints;


            _context.Clients.Update(clientRent);
       
            var daysBooked = rents.DaysBooked;
            var daysExtra = rents.DaysTotal - rents.DaysBooked;

           var price = RentalService.CalculatePrice(typeCar,daysBooked, daysExtra);


            rents.Price= price;
          
            _context.Rents.Add(rents);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRents", new { id = rents.Id }, rents);
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRents(int id)
        {
            var rents = await _context.Rents.FindAsync(id);
            if (rents == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(rents);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentsExists(int id)
        {
            return _context.Rents.Any(e => e.Id == id);
        }
    }
}
