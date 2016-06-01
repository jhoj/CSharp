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
    [Route("api/RecommendedOilConsumption")]
    public class RecommendedOilConsumptionController : Controller
    {
        private ApplicationDbContext _context;

        public RecommendedOilConsumptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RecommendedOilConsumption
        [HttpGet]
        public IEnumerable<RecommendedOilConsumption> GetRecommendedOilConsumption()
        {
            return _context.RecommendedOilConsumption;
        }

        // GET: api/RecommendedOilConsumption/5
        [HttpGet("{id}", Name = "GetRecommendedOilConsumption")]
        public async Task<IActionResult> GetRecommendedOilConsumption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            RecommendedOilConsumption recommendedOilConsumption = await _context.RecommendedOilConsumption.SingleAsync(m => m.Id == id);

            if (recommendedOilConsumption == null)
            {
                return HttpNotFound();
            }

            return Ok(recommendedOilConsumption);
        }

        // PUT: api/RecommendedOilConsumption/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecommendedOilConsumption([FromRoute] int id, [FromBody] RecommendedOilConsumption recommendedOilConsumption)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != recommendedOilConsumption.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(recommendedOilConsumption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecommendedOilConsumptionExists(id))
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

        // POST: api/RecommendedOilConsumption
        [HttpPost]
        public async Task<IActionResult> PostRecommendedOilConsumption([FromBody] RecommendedOilConsumption recommendedOilConsumption)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.RecommendedOilConsumption.Add(recommendedOilConsumption);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecommendedOilConsumptionExists(recommendedOilConsumption.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetRecommendedOilConsumption", new { id = recommendedOilConsumption.Id }, recommendedOilConsumption);
        }

        // DELETE: api/RecommendedOilConsumption/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendedOilConsumption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            RecommendedOilConsumption recommendedOilConsumption = await _context.RecommendedOilConsumption.SingleAsync(m => m.Id == id);
            if (recommendedOilConsumption == null)
            {
                return HttpNotFound();
            }

            _context.RecommendedOilConsumption.Remove(recommendedOilConsumption);
            await _context.SaveChangesAsync();

            return Ok(recommendedOilConsumption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecommendedOilConsumptionExists(int id)
        {
            return _context.RecommendedOilConsumption.Count(e => e.Id == id) > 0;
        }
    }
}