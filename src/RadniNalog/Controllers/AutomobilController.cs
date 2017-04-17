using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadniNalog.Data;
using RadniNalog.Models;

namespace RadniNalog.Controllers
{
    [Produces("application/json")]
    [Route("api/Automobil")]
    public class AutomobilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutomobilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Automobil
        [HttpGet]
        public IEnumerable<Automobil> GetAutomobili()
        {
            return _context.Automobili;
        }

        // GET: api/Automobil/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutomobil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Automobil automobil = await _context.Automobili.SingleOrDefaultAsync(m => m.ID == id);

            if (automobil == null)
            {
                return NotFound();
            }

            return Ok(automobil);
        }

        // PUT: api/Automobil/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutomobil([FromRoute] int id, [FromBody] Automobil automobil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != automobil.ID)
            {
                return BadRequest();
            }

            _context.Entry(automobil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomobilExists(id))
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

        // POST: api/Automobil
        [HttpPost]
        public async Task<IActionResult> PostAutomobil([FromBody] Automobil automobil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Automobili.Add(automobil);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AutomobilExists(automobil.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAutomobil", new { id = automobil.ID }, automobil);
        }

        // DELETE: api/Automobil/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutomobil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Automobil automobil = await _context.Automobili.SingleOrDefaultAsync(m => m.ID == id);
            if (automobil == null)
            {
                return NotFound();
            }

            _context.Automobili.Remove(automobil);
            await _context.SaveChangesAsync();

            return Ok(automobil);
        }

        private bool AutomobilExists(int id)
        {
            return _context.Automobili.Any(e => e.ID == id);
        }
    }
}