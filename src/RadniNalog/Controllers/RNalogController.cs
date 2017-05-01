using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadniNalog.Data;
using RadniNalog.Models;
using System.Globalization;
using RadniNalog.ViewModels;

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
        public IEnumerable<RNalog> GetRadniNalozi(bool includeAll=false)
        {

            if (includeAll)
            {


                return _context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil);

                

              
               

            }
            else
            {



                return _context.RadniNalozi;
            }
        }


        [HttpGet,Route("/api/nalozi")]
        public IEnumerable<RNalogViewModel> GetRadniNalozi2(bool includeAll = false)
        {

            var lista = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil).ToList());

            return lista;
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
        public async Task<IActionResult> PostRNalog([FromBody]  RNalog rNalog)
        {
            string correctdate = rNalog.Datum.ToString();
            //DateTime dt = Convert.ToDateTime(rNalog.Datum.ToString("MM/dd/yyyy"));
            //rNalog.Datum = dt;

           
            rNalog.Datum = DateTime.Now;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            Automobil auto = _context.Automobili.Where(a => a.ID == rNalog.AutomobilID).FirstOrDefault();
            MjestoRada rad = _context.MjestoRada.Where(m => m.ID == rNalog.MjestoRadaID).FirstOrDefault();
            VrstaRada vrsta = _context.VrstaRada.Where(vr => vr.ID == rNalog.VrstaRadaID).FirstOrDefault();

            //rNalog.Automobil = auto;
            //rNalog.MjestoRada = rad;
            //rNalog.VrstaRada = vrsta;


            // string correctdate = rNalog.Datum.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            // DateTime dt = DateTime.ParseExact(correctdate, "dd/MM/yyyy", CultureInfo.GetCultureInfoByIetfLanguageTag("hr-HR"));







            RNalog nalog = new RNalog
            {
                Automobil = auto,
                MjestoRada = rad,
                VrstaRada = vrsta,
                AutomobilID = rNalog.AutomobilID,
                Datum = rNalog.Datum,
                Izvrsitelj2 = rNalog.Izvrsitelj2,
                Izvrsitelj3 = rNalog.Izvrsitelj3,
                Materijal = rNalog.Materijal,
                MjestoRadaID = rNalog.MjestoRadaID,
                OpisRadova = rNalog.OpisRadova,
                PutniNalog = rNalog.PutniNalog,
                Rukovoditelj = rNalog.Rukovoditelj,
                VrstaRadaID = rNalog.VrstaRadaID



            };



            _context.Entry(nalog).State = EntityState.Added;


           // _context.RadniNalozi.Add(rNalog);
            
            try
            {
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RNalogExists(nalog.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRNalog", new { id = nalog.ID }, nalog);
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