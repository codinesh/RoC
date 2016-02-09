using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideOnCab.Models
{
    public class Cab
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public bool IsAvailable { get; set; }

        public Vehicle Vehicle { get; set; }
    }

}
