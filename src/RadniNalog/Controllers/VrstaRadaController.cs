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
    [Route("api/VrstaRada")]
    public class VrstaRadaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VrstaRadaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VrstaRada
        [HttpGet]
        public IEnumerable<VrstaRada> GetVrstaRada()
        {
            return _context.VrstaRada;
        }

        // GET: api/VrstaRada/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVrstaRada([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VrstaRada vrstaRada = await _context.VrstaRada.SingleOrDefaultAsync(m => m.ID == id);

            if (vrstaRada == null)
            {
                return NotFound();
            }

            return Ok(vrstaRada);
        }

        // PUT: api/VrstaRada/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVrstaRada([FromRoute] int id, [FromBody] VrstaRada vrstaRada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vrstaRada.ID)
            {
                return BadRequest();
            }

            _context.Entry(vrstaRada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VrstaRadaExists(id))
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

        // POST: api/VrstaRada
        [HttpPost]
        public async Task<IActionResult> PostVrstaRada([FromBody] VrstaRada vrstaRada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VrstaRada.Add(vrstaRada);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VrstaRadaExists(vrstaRada.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVrstaRada", new { id = vrstaRada.ID }, vrstaRada);
        }

        // DELETE: api/VrstaRada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVrstaRada([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VrstaRada vrstaRada = await _context.VrstaRada.SingleOrDefaultAsync(m => m.ID == id);
            if (vrstaRada == null)
            {
                return NotFound();
            }

            _context.VrstaRada.Remove(vrstaRada);
            await _context.SaveChangesAsync();

            return Ok(vrstaRada);
        }

        private bool VrstaRadaExists(int id)
        {
            return _context.VrstaRada.Any(e => e.ID == id);
        }
    }
}