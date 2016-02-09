using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RideOnCab.Models;
using RideOnCab.Utilities;
using System.Collections.Generic;
using Microsoft.AspNet.Authorization;
using RideOnCab.ViewModels;

namespace RideOnCab.Controllers
{
    [Authorize]
    public class RidesController : Controller
    {
        private ApplicationDbContext _context;
        private Repository _repo;

        public RidesController(ApplicationDbContext context, Repository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: Rides
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ride.Include(v => v.Vehicle).ToListAsync());
        }

        // GET: Rides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Ride ride = await _context.Ride.Include(v => v.Vehicle).SingleAsync(m => m.Id == id);
            if (ride == null)
            {
                return HttpNotFound();
            }

            return View(ride);
        }

        // GET: Rides/Create
        public IActionResult Create()
        {
            RideViewModel rideVM = new RideViewModel();
            rideVM.AvailableVehicles = _repo.GetVehicles() as List<Vehicle>;
            foreach (var item in rideVM.AvailableVehicles)
            {
                rideVM.AvailableVehicles1.Add(
                    new SelectListItem
                    {
                        Text = item.Manufacturer + " " + item.Model,
                        Value = item.Id.ToString()
                    }
                );
            }
            return View(rideVM);
        }

        // POST: Rides/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RideViewModel ride)
        {
            if (ModelState.IsValid)
            {
                //rideVM.Ride.Vehicle = new Vehicle { Id = rideVM.SelectedVehicleId };
                var rideObj = new Ride { Id = ride.Id, Source = ride.Source, Destination = ride.Destination, Fare = ride.Fare, WaitingChargesPerMinute = ride.WaitingChargesPerMinute, Vehicle = new Vehicle { Id = ride.SelectedVehicleId } };

                _context.Ride.Add(rideObj);
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

            Ride ride = await _context.Ride.Include(v => v.Vehicle).SingleAsync(m => m.Id == id);
            if (ride == null)
            {
                return HttpNotFound();
            }
            RideViewModel rideVM = new RideViewModel
            {
                Id = ride.Id,
                Source = ride.Source,
                Destination = ride.Destination,
                Fare = ride.Fare,
                WaitingChargesPerMinute = ride.WaitingChargesPerMinute,
                Vehicle = ride.Vehicle,
                AvailableVehicles = _repo.GetVehicles() as List<Vehicle>,
                SelectedVehicleId = ride.Vehicle.Id
            };
            foreach (var item in rideVM.AvailableVehicles)
            {
                rideVM.AvailableVehicles1.Add(
                    new SelectListItem
                    {
                        Text = item.Manufacturer + " " + item.Model,
                        Value = item.Id.ToString(),
                        Selected = item.Id == ride.Id ? true : false
                    }
                );
            }

            return View(rideVM);
        }

        // POST: Rides/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RideViewModel ride)
        {
            if (ModelState.IsValid)
            {
                //ride.Ride.Vehicle.Id = ride.SelectedVehicleId;
                var rideObj = new Ride { Id = ride.Id, Source = ride.Source, Destination = ride.Destination, Fare = ride.Fare, WaitingChargesPerMinute = ride.WaitingChargesPerMinute, Vehicle = new Vehicle { Id = ride.SelectedVehicleId } };
                _context.Update(rideObj);
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
