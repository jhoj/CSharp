using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductionsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Productions
        public IActionResult Index()
        {
            return View(_context.Production.ToList());
        }

        // GET: Productions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Production production = _context.Production.Single(m => m.Id == id);
            if (production == null)
            {
                return HttpNotFound();
            }

            return View(production);
        }

        // GET: Productions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Production production)
        {
            if (ModelState.IsValid)
            {
                _context.Production.Add(production);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(production);
        }

        // GET: Productions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Production production = _context.Production.Single(m => m.Id == id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        // POST: Productions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Production production)
        {
            if (ModelState.IsValid)
            {
                _context.Update(production);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(production);
        }

        // GET: Productions/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Production production = _context.Production.Single(m => m.Id == id);
            if (production == null)
            {
                return HttpNotFound();
            }

            return View(production);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Production production = _context.Production.Single(m => m.Id == id);
            _context.Production.Remove(production);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
