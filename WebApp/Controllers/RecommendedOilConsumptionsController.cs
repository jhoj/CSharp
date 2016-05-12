using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RecommendedOilConsumptionsController : Controller
    {
        private ApplicationDbContext _context;

        public RecommendedOilConsumptionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: RecommendedOilConsumptions
        public IActionResult Index()
        {
            return View(_context.RecommendedOilConsumption.ToList());
        }

        // GET: RecommendedOilConsumptions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RecommendedOilConsumption recommendedOilConsumption = _context.RecommendedOilConsumption.Single(m => m.Id == id);
            if (recommendedOilConsumption == null)
            {
                return HttpNotFound();
            }

            return View(recommendedOilConsumption);
        }

        // GET: RecommendedOilConsumptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecommendedOilConsumptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecommendedOilConsumption recommendedOilConsumption)
        {
            if (ModelState.IsValid)
            {
                _context.RecommendedOilConsumption.Add(recommendedOilConsumption);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recommendedOilConsumption);
        }

        // GET: RecommendedOilConsumptions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RecommendedOilConsumption recommendedOilConsumption = _context.RecommendedOilConsumption.Single(m => m.Id == id);
            if (recommendedOilConsumption == null)
            {
                return HttpNotFound();
            }
            return View(recommendedOilConsumption);
        }

        // POST: RecommendedOilConsumptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RecommendedOilConsumption recommendedOilConsumption)
        {
            if (ModelState.IsValid)
            {
                _context.Update(recommendedOilConsumption);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recommendedOilConsumption);
        }

        // GET: RecommendedOilConsumptions/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RecommendedOilConsumption recommendedOilConsumption = _context.RecommendedOilConsumption.Single(m => m.Id == id);
            if (recommendedOilConsumption == null)
            {
                return HttpNotFound();
            }

            return View(recommendedOilConsumption);
        }

        // POST: RecommendedOilConsumptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            RecommendedOilConsumption recommendedOilConsumption = _context.RecommendedOilConsumption.Single(m => m.Id == id);
            _context.RecommendedOilConsumption.Remove(recommendedOilConsumption);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
