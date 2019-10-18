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
    [Route("api/drzava")]
    [ApiController]
    public class DrzavaApi : ControllerBase
    {
        private readonly KoiosDbContext _context;

        public DrzavaApi(KoiosDbContext context)
        {
            _context = context;
        }

        // GET: api/Koios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drzava>>> GetDrzave()
        {
            return await _context.Drzave.ToListAsync();
        }

        // GET: api/Koios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drzava>> GetDrzava(int id)
        {
            var drzava = await _context.Drzave.FindAsync(id);

            if (drzava == null)
            {
                return NotFound();
            }

            return drzava;
        }

        // PUT: api/Koios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrzava(Drzava drzava)
        {
            //if (id != drzava.Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(drzava).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrzavaExists(drzava.Id))
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

        // POST: api/Koios
        [HttpPost]
        public async Task<ActionResult<Drzava>> PostDrzava(Drzava drzava)
        {
            _context.Drzave.Add(drzava);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrzava", new { id = drzava.Id }, drzava);
        }
        
        
        // DELETE: api/Koios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drzava>> DeleteDrzava(int id)
        {
            var drzava = await _context.Drzave.FindAsync(id);
            if (drzava == null)
            {
                return NotFound();
            }

            _context.Drzave.Remove(drzava);
            await _context.SaveChangesAsync();

            return drzava;
        }

        private bool DrzavaExists(int id)
        {
            return _context.Drzave.Any(e => e.Id == id);
        }
    }
}
