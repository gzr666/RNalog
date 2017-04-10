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
    [Route("api/zaposlenici")]
    public class ZaposlenikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZaposlenikController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Zaposleniks
        [HttpGet]
        public IEnumerable<Zaposlenik> GetZaposlenici()
        {
            return _context.Zaposlenici;
        }

        // GET: api/Zaposleniks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetZaposlenik([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Zaposlenik zaposlenik = await _context.Zaposlenici.SingleOrDefaultAsync(m => m.ID == id);

            if (zaposlenik == null)
            {
                return NotFound();
            }

            return Ok(zaposlenik);
        }

        // PUT: api/Zaposleniks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZaposlenik([FromRoute] int id, [FromBody] Zaposlenik zaposlenik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zaposlenik.ID)
            {
                return BadRequest();
            }

            _context.Entry(zaposlenik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaposlenikExists(id))
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

        // POST: api/Zaposleniks
        [HttpPost]
        public async Task<IActionResult> PostZaposlenik([FromBody] Zaposlenik zaposlenik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Zaposlenici.Add(zaposlenik);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZaposlenikExists(zaposlenik.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZaposlenik", new { id = zaposlenik.ID }, zaposlenik);
        }

        // DELETE: api/Zaposleniks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZaposlenik([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Zaposlenik zaposlenik = await _context.Zaposlenici.SingleOrDefaultAsync(m => m.ID == id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            _context.Zaposlenici.Remove(zaposlenik);
            await _context.SaveChangesAsync();

            return Ok(zaposlenik);
        }

        private bool ZaposlenikExists(int id)
        {
            return _context.Zaposlenici.Any(e => e.ID == id);
        }
    }
}