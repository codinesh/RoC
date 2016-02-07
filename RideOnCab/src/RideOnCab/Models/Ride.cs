using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideOnCab.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal Fare { get; set; }
        public decimal WaitingChargesPerMinute { get; set; }
        public Vehicle Cab { get; set; }
    }

}
