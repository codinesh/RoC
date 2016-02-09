using RideOnCab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideOnCab.Utilities
{
    public class Repository
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Vehicle> GetVehicles()
        {
            return _context.Vehicles.ToList();
        }
    }
}
