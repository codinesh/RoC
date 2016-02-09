using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RideOnCab.Models
{
    public class Ride
    {
        public int Id { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public decimal Fare { get; set; }
        [Display(Name ="Waiting chanrges/min")]
        public decimal WaitingChargesPerMinute { get; set; }
        public Vehicle Vehicle { get; set; }
    }

}
