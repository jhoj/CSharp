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
    [Route("api/OilConsumption")]
    public class OilConsumptionController : Controller
    {
        private ApplicationDbContext _context;

        public OilConsumptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OilConsumption
        [HttpGet]
        public IEnumerable<OilConsumption> GetOilConsumption()
        {
            return _context.OilConsumption;
        }

        // GET: api/OilConsumption/5
        [HttpGet("{id}", Name = "GetOilConsumption")]
        public async Task<IActionResult> GetOilConsumption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            OilConsumption oilConsumption = await _context.OilConsumption.SingleAsync(m => m.Id == id);

            if (oilConsumption == null)
            {
                return HttpNotFound();
            }

            return Ok(oilConsumption);
        }

        // PUT: api/OilConsumption/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOilConsumption([FromRoute] int id, [FromBody] OilConsumption oilConsumption)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != oilConsumption.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(oilConsumption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OilConsumptionExists(id))
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

        // POST: api/OilConsumption
        [HttpPost]
        public async Task<IActionResult> PostOilConsumption([FromBody] OilConsumption oilConsumption)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.OilConsumption.Add(oilConsumption);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OilConsumptionExists(oilConsumption.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetOilConsumption", new { id = oilConsumption.Id }, oilConsumption);
        }

        // DELETE: api/OilConsumption/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOilConsumption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            OilConsumption oilConsumption = await _context.OilConsumption.SingleAsync(m => m.Id == id);
            if (oilConsumption == null)
            {
                return HttpNotFound();
            }

            _context.OilConsumption.Remove(oilConsumption);
            await _context.SaveChangesAsync();

            return Ok(oilConsumption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OilConsumptionExists(int id)
        {
            return _context.OilConsumption.Count(e => e.Id == id) > 0;
        }
    }
}