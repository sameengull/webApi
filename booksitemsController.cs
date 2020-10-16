using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using booksapi.models;

namespace booksapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksitemsController : ControllerBase
    {
        private readonly bookscontext _context;

        public booksitemsController(bookscontext context)
        {
            _context = context;
        }

        // GET: api/booksitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<booksitem>>> Getbooksitems()
        {
            return await _context.booksitems.ToListAsync();
        }

        // GET: api/booksitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<booksitem>> Getbooksitem(long id)
        {
            var booksitem = await _context.booksitems.FindAsync(id);

            if (booksitem == null)
            {
                return NotFound();
            }

            return booksitem;
        }

        // PUT: api/booksitems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbooksitem(long id, booksitem booksitem)
        {
            if (id != booksitem.Id)
            {
                return BadRequest();
            }

            _context.Entry(booksitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!booksitemExists(id))
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

        // POST: api/booksitems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<booksitem>> Postbooksitem(booksitem booksitem)
        {
            _context.booksitems.Add(booksitem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbooksitem", new { id = booksitem.Id }, booksitem);
        }

        // DELETE: api/booksitems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<booksitem>> Deletebooksitem(long id)
        {
            var booksitem = await _context.booksitems.FindAsync(id);
            if (booksitem == null)
            {
                return NotFound();
            }

            _context.booksitems.Remove(booksitem);
            await _context.SaveChangesAsync();

            return booksitem;
        }

        private bool booksitemExists(long id)
        {
            return _context.booksitems.Any(e => e.Id == id);
        }
    }
}
