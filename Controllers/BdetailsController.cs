using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingDetails.Models;

namespace BookingDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BdetailsController : ControllerBase
    {
        private readonly BookingDetailsContext _context=new BookingDetailsContext();

       /* public BdetailsController(BookingDetailsContext context)
        {
            _context = context;
        }*/

        // GET: api/Bdetails
       /* [HttpGet]
        public async Task<ActionResult<IEnumerable<Bdetail>>> GetBdetails()
        {
          if (_context.Bdetails == null)
          {
              return NotFound();
          }
            return await _context.Bdetails.ToListAsync();
        }*/

        // GET: api/Bdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bdetail>> GetBdetail(int id)
        {
          if (_context.Bdetails == null)
          {
              return NotFound();
          }
            var bdetail = await _context.Bdetails.FindAsync(id);

            if (bdetail == null)
            {
                return NotFound();
            }

            return bdetail;
        }

        // PUT: api/Bdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPut("{id}")]
        public async Task<IActionResult> PutBdetail(int id, Bdetail bdetail)
        {
            if (id != bdetail.Bid)
            {
                return BadRequest();
            }

            _context.Entry(bdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Bdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bdetail>> PostBdetail(Bdetail bdetail)
        {
          if (_context.Bdetails == null)
          {
              return Problem("Entity set 'BookingDetailsContext.Bdetails'  is null.");
          }
            _context.Bdetails.Add(bdetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BdetailExists(bdetail.Bid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBdetail", new { id = bdetail.Bid }, bdetail);
        }

        // DELETE: api/Bdetails/5
       /* [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdetail(int id)
        {
            if (_context.Bdetails == null)
            {
                return NotFound();
            }
            var bdetail = await _context.Bdetails.FindAsync(id);
            if (bdetail == null)
            {
                return NotFound();
            }

            _context.Bdetails.Remove(bdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool BdetailExists(int id)
        {
            return (_context.Bdetails?.Any(e => e.Bid == id)).GetValueOrDefault();
        }
    }
}
