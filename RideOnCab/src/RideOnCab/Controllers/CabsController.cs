using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RideOnCab.Models;

namespace RideOnCab.Controllers
{
    public class CabsController : Controller
    {
        private ApplicationDbContext _context;

        public CabsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cabs.ToListAsync());
        }

        // GET: Cabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cab cab = await _context.Cabs.SingleAsync(m => m.Id == id);
            if (cab == null)
            {
                return HttpNotFound();
            }

            return View(cab);
        }

        // GET: Cabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cabs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cab cab)
        {
            if (ModelState.IsValid)
            {
                _context.Cabs.Add(cab);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cab);
        }

        // GET: Cabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cab cab = await _context.Cabs.SingleAsync(m => m.Id == id);
            if (cab == null)
            {
                return HttpNotFound();
            }
            return View(cab);
        }

        // POST: Cabs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cab cab)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cab);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cab);
        }

        // GET: Cabs/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cab cab = await _context.Cabs.SingleAsync(m => m.Id == id);
            if (cab == null)
            {
                return HttpNotFound();
            }

            return View(cab);
        }

        // POST: Cabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Cab cab = await _context.Cabs.SingleAsync(m => m.Id == id);
            _context.Cabs.Remove(cab);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
