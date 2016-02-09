using RideOnCab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideOnCab.Data
{
    public class InitialData
    {
        private ApplicationDbContext _context;

        public InitialData(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SeedData()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            List<Cab> cabs = new List<Cab>();

            if (!_context.Vehicles.Any())
            {
                vehicles = new List<Vehicle> {
                    new Vehicle { Manufacturer = "Honda", Model = "Accord", NumberOfSeats = 4},
                    new Vehicle { Manufacturer = "Tata", Model = "Indica", NumberOfSeats = 4 },
                    new Vehicle { Manufacturer = "Mahindra", Model = "Verito", NumberOfSeats = 4 },
                    new Vehicle { Manufacturer = "Hyunday", Model = "i20", NumberOfSeats = 4 },
                    new Vehicle { Manufacturer = "Sujuki", Model = "Beleno", NumberOfSeats = 4 }
                };
            }

            if (!_context.Cabs.Any())
            {
                cabs = new List<Cab> {
                    new Cab { IsAvailable = true, Vehicle = vehicles[0],  RegistrationNumber = "AP28 DW 4636" },
                    new Cab { IsAvailable = true, Vehicle = vehicles[1],  RegistrationNumber = "AP28 DW 4636" },
                    new Cab { IsAvailable = true, Vehicle = vehicles[2],  RegistrationNumber = "AP28 DW 4636" },
                    new Cab { IsAvailable = true, Vehicle = vehicles[3],  RegistrationNumber = "AP28 DW 4636" },
                    new Cab { IsAvailable = true, Vehicle = vehicles[4],  RegistrationNumber = "AP28 DW 4636" }
                };
            }

            _context.Vehicles.AddRange(vehicles);
            _context.Cabs.AddRange(cabs);

            _context.SaveChangesAsync();
        }
    }
}
