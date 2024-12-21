using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SU6Rest.Api.Date;
using SU6Rest.Api.Models;

namespace SU6Rest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SaleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sale
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSale()
        {
          if (_context.Sale == null)
          {
              return NotFound();
          }
            return await _context.Sale.ToListAsync();
        }

        // GET: api/Sale/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(Guid id)
        {
          if (_context.Sale == null)
          {
              return NotFound();
          }
            var sale = await _context.Sale.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // PUT: api/Sale/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(Guid id, Sale sale)
        {
            if (id != sale.SaleId)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sale
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
          if (_context.Sale == null)
          {
              return Problem("Entity set 'AppDbContext.Sale'  is null.");
          }
            _context.Sale.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.SaleId }, sale);
        }

        // DELETE: api/Sale/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(Guid id)
        {
            if (_context.Sale == null)
            {
                return NotFound();
            }
            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleExists(Guid id)
        {
            return (_context.Sale?.Any(e => e.SaleId == id)).GetValueOrDefault();
        }
    }
}
