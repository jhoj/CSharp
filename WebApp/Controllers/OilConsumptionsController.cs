using Microsoft.AspNet.Mvc;
using System;
using System.Linq;
using WebApp.Models;
using System.Data.Objects;
using System.Data;

namespace WebApp.Controllers
{
    public class OilConsumptionsController : Controller
    {
        private ApplicationDbContext _context;

        public OilConsumptionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: OilConsumptions
        public IActionResult Index()
        {
           return View(_context.OilConsumption.ToList());
        }

        // GET: OilConsumptions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            OilConsumption oilConsumption = _context.OilConsumption.Single(m => m.Id == id);
            if (oilConsumption == null)
            {
                return HttpNotFound();
            }

            return View(oilConsumption);
        }

        // GET: OilConsumptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OilConsumptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OilConsumption oilConsumption)
        {
            if (ModelState.IsValid)
            {
                _context.OilConsumption.Add(oilConsumption);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oilConsumption);
        }

        // GET: OilConsumptions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            OilConsumption oilConsumption = _context.OilConsumption.Single(m => m.Id == id);
            if (oilConsumption == null)
            {
                return HttpNotFound();
            }
            return View(oilConsumption);
        }

        // POST: OilConsumptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OilConsumption oilConsumption)
        {
            if (ModelState.IsValid)
            {
                _context.Update(oilConsumption);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oilConsumption);
        }

        // GET: OilConsumptions/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            OilConsumption oilConsumption = _context.OilConsumption.Single(m => m.Id == id);
            if (oilConsumption == null)
            {
                return HttpNotFound();
            }

            return View(oilConsumption);
        }

        // POST: OilConsumptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            OilConsumption oilConsumption = _context.OilConsumption.Single(m => m.Id == id);
            _context.OilConsumption.Remove(oilConsumption);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
