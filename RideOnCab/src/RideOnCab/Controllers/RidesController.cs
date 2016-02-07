using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RideOnCab.Models;

namespace RideOnCab.Controllers
{
    public class RidesController : Controller
    {
        private ApplicationDbContext _context;

        public RidesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Rides
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ride.ToListAsync());
        }

        // GET: Rides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Ride ride = await _context.Ride.SingleAsync(m => m.Id == id);
            if (ride == null)
            {
                return HttpNotFound();
            }

            return View(ride);
        }

        // GET: Rides/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rides/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ride ride)
        {
            if (ModelState.IsValid)
            {
                _context.Ride.Add(ride);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ride);
        }

        // GET: Rides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Ride ride = await _context.Ride.SingleAsync(m => m.Id == id);
            if (ride == null)
            {
                return HttpNotFound();
            }
            return View(ride);
        }

        // POST: Rides/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ride ride)
        {
            if (ModelState.IsValid)
            {
                _context.Update(ride);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ride);
        }

        // GET: Rides/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Ride ride = await _context.Ride.SingleAsync(m => m.Id == id);
            if (ride == null)
            {
                return HttpNotFound();
            }

            return View(ride);
        }

        // POST: Rides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Ride ride = await _context.Ride.SingleAsync(m => m.Id == id);
            _context.Ride.Remove(ride);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
