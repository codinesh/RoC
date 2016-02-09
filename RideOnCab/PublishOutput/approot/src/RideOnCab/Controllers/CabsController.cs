using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RideOnCab.Models;
using RideOnCab.ViewModels;
using Microsoft.AspNet.Authorization;
using RideOnCab.Utilities;
using System.Collections.Generic;

namespace RideOnCab.Controllers
{
    [Authorize]
    public class CabsController : Controller
    {
        private ApplicationDbContext _context;
        private Repository _repo;

        public CabsController(ApplicationDbContext context, Repository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: Cabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cabs.Include(v => v.Vehicle).ToListAsync());
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
            CabViewModel cabsVM = new CabViewModel();
            cabsVM.AvailableVehicles = _repo.GetVehicles() as List<Vehicle>;
            foreach (var item in cabsVM.AvailableVehicles)
            {
                cabsVM.AvailableVehicles1.Add(
                    new SelectListItem
                    {
                        Text = item.Manufacturer + " " + item.Model,
                        Value = item.Id.ToString()
                    }
                );
            }
            return View(cabsVM);
        }

        // POST: Cabs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CabViewModel cab)
        {
            if (ModelState.IsValid)
            {
                var cabObj = new Cab { RegistrationNumber = cab.RegistrationNumber, Vehicle = new Vehicle { Id = cab.SelectedVehicleId } };
                _context.Cabs.Add(cabObj);
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

            Cab cab = await _context.Cabs.Include(v => v.Vehicle).SingleAsync(m => m.Id == id);
            if (cab == null)
            {
                return HttpNotFound();
            }
            CabViewModel cabVM = new CabViewModel
            {
                AvailableVehicles = _repo.GetVehicles() as List<Vehicle>,
                Id = cab.Id,
                IsAvailable = cab.IsAvailable,
                RegistrationNumber = cab.RegistrationNumber,
                Vehicle = cab.Vehicle,
                SelectedVehicleId = cab.Vehicle.Id
            };

            foreach (var item in cabVM.AvailableVehicles)
            {
                cabVM.AvailableVehicles1.Add(
                    new SelectListItem
                    {
                        Text = item.Manufacturer + " " + item.Model,
                        Value = item.Id.ToString(),
                        Selected = item.Id == cab.Id ? true : false
                    }
                );
            }

            return View(cabVM);
        }

        // POST: Cabs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CabViewModel cab)
        {
            if (ModelState.IsValid)
            {
                var cabObj = new Cab { RegistrationNumber = cab.RegistrationNumber, Vehicle = new Vehicle { Id = cab.SelectedVehicleId } };
                _context.Update(cabObj);
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
