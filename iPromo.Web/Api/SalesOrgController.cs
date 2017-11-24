using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iPromo.Entities;

namespace iPromo.Web.Api
{
    [Produces("application/json")]
    [Route("api/SalesOrg")]
    public class SalesOrgController : Controller
    {
        private readonly iPromoDataContext _context;

        public SalesOrgController(iPromoDataContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrg
        [HttpGet]
        public IEnumerable<SalesOrg> GetSalesOrg()
        {
            return _context.SalesOrg;
        }

        // GET: api/SalesOrg/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesOrg([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salesOrg = await _context.SalesOrg.SingleOrDefaultAsync(m => m.UserID == id);

            if (salesOrg == null)
            {
                return NotFound();
            }

            return Ok(salesOrg);
        }

        // PUT: api/SalesOrg/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesOrg([FromRoute] int id, [FromBody] SalesOrg salesOrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesOrg.UserID)
            {
                return BadRequest();
            }

            _context.Entry(salesOrg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrgExists(id))
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

        // POST: api/SalesOrg
        [HttpPost]
        public async Task<IActionResult> PostSalesOrg([FromBody] SalesOrg salesOrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SalesOrg.Add(salesOrg);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesOrgExists(salesOrg.UserID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesOrg", new { id = salesOrg.UserID }, salesOrg);
        }

        // DELETE: api/SalesOrg/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesOrg([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salesOrg = await _context.SalesOrg.SingleOrDefaultAsync(m => m.UserID == id);
            if (salesOrg == null)
            {
                return NotFound();
            }

            _context.SalesOrg.Remove(salesOrg);
            await _context.SaveChangesAsync();

            return Ok(salesOrg);
        }

        private bool SalesOrgExists(int id)
        {
            return _context.SalesOrg.Any(e => e.UserID == id);
        }
    }
}