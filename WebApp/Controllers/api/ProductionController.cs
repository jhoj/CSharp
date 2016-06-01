using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Production")]
    public class ProductionController : Controller
    {
        private ApplicationDbContext _context;

        public ProductionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Production
        [HttpGet]
        public IEnumerable<Production> GetProduction()
        {
            return _context.Production;
        }

        // GET: api/Production/5
        [HttpGet("{id}", Name = "GetProduction")]
        public async Task<IActionResult> GetProduction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Production production = await _context.Production.SingleAsync(m => m.Id == id);

            if (production == null)
            {
                return HttpNotFound();
            }

            return Ok(production);
        }

        // PUT: api/Production/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduction([FromRoute] int id, [FromBody] Production production)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != production.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(production).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Production
        [HttpPost]
        public async Task<IActionResult> PostProduction([FromBody] Production production)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Production.Add(production);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductionExists(production.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetProduction", new { id = production.Id }, production);
        }

        // DELETE: api/Production/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Production production = await _context.Production.SingleAsync(m => m.Id == id);
            if (production == null)
            {
                return HttpNotFound();
            }

            _context.Production.Remove(production);
            await _context.SaveChangesAsync();

            return Ok(production);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductionExists(int id)
        {
            return _context.Production.Count(e => e.Id == id) > 0;
        }
    }
}