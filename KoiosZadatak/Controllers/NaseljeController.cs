using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiosZadatak.Models;

namespace KoiosZadatak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaseljeController : ControllerBase
    {
        private readonly KoiosDbContext _context;

        public NaseljeController(KoiosDbContext context)
        {
            _context = context;
        }

        // GET: api/Naselje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Naselje>>> GetNaselja()
        {
            return await _context.Naselja.ToListAsync();
        }

        // GET: api/Naselje/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Naselje>> GetNaselje(int id)
        {
            var naselje = await _context.Naselja.FindAsync(id);
            if (naselje == null)
            {
                return NotFound();
            }

            return naselje;
        }

        // PUT: api/Naselje/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaselje(int id, Naselje naselje)
        {
            if (id != naselje.Id)
            {
                return BadRequest();
            }

            _context.Entry(naselje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaseljeExists(id))
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

        //POST: api/Naselje
       [HttpPost]
        public async Task<ActionResult<Naselje>> PostNaselje(Naselje naselje)
        {
            _context.Naselja.Add(naselje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNaselje", new { id = naselje.Id }, naselje);
        }
        //[HttpPost]
        //public async Task<ActionResult<Naselje>> PostNaselje(string naziv, string drzavaId, string pbr)
        //{
        //    Naselje naselje = new Naselje { DrzavaId = int.Parse(drzavaId), PostanskiBroj = pbr, Naziv = naziv };
        //    _context.Naselja.Add(naselje);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetNaselje", new { id = naselje.Id }, naselje);
        //}
        // DELETE: api/Naselje/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Naselje>> DeleteNaselje(int id)
        {
            var naselje = await _context.Naselja.FindAsync(id);
            if (naselje == null)
            {
                return NotFound();
            }

            _context.Naselja.Remove(naselje);
            await _context.SaveChangesAsync();

            return naselje;
        }

        private bool NaseljeExists(int id)
        {
            return _context.Naselja.Any(e => e.Id == id);
        }
    }
}
