using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MachinesController : Controller
    {
        private ApplicationDbContext _context;

        public MachinesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Machines
        public IActionResult Index()
        {
            return View(_context.Machine.ToList());
        }

        // GET: Machines/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Machine machine = _context.Machine.Single(m => m.Id == id);
            if (machine == null)
            {
                return HttpNotFound();
            }

            return View(machine);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Machines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Machine machine)
        {
            if (ModelState.IsValid)
            {
                _context.Machine.Add(machine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machine);
        }

        // GET: Machines/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Machine machine = _context.Machine.Single(m => m.Id == id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        // POST: Machines/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Machine machine)
        {
            if (ModelState.IsValid)
            {
                _context.Update(machine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machine);
        }

        // GET: Machines/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Machine machine = _context.Machine.Single(m => m.Id == id);
            if (machine == null)
            {
                return HttpNotFound();
            }

            return View(machine);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Machine machine = _context.Machine.Single(m => m.Id == id);
            _context.Machine.Remove(machine);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
