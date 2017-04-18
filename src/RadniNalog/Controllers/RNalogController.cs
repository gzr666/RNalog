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
    [Route("api/RNalog")]
    public class RNalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RNalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RNalog
        [HttpGet]
        public IEnumerable<RNalog> GetRadniNalozi()
        {
            return _context.RadniNalozi;
        }

        // GET: api/RNalog/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRNalog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RNalog rNalog = await _context.RadniNalozi.SingleOrDefaultAsync(m => m.ID == id);

            if (rNalog == null)
            {
                return NotFound();
            }

            return Ok(rNalog);
        }

        // PUT: api/RNalog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRNalog([FromRoute] int id, [FromBody] RNalog rNalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rNalog.ID)
            {
                return BadRequest();
            }

            _context.Entry(rNalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RNalogExists(id))
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

        // POST: api/RNalog
        [HttpPost]
        public async Task<IActionResult> PostRNalog([FromBody] RNalog rNalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RadniNalozi.Add(rNalog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RNalogExists(rNalog.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRNalog", new { id = rNalog.ID }, rNalog);
        }

        // DELETE: api/RNalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRNalog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RNalog rNalog = await _context.RadniNalozi.SingleOrDefaultAsync(m => m.ID == id);
            if (rNalog == null)
            {
                return NotFound();
            }

            _context.RadniNalozi.Remove(rNalog);
            await _context.SaveChangesAsync();

            return Ok(rNalog);
        }

        private bool RNalogExists(int id)
        {
            return _context.RadniNalozi.Any(e => e.ID == id);
        }
    }
}