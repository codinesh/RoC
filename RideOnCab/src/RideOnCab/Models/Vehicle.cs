using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RideOnCab.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        [Display(Name = "Seats Available")]
        public int NumberOfSeats { get; set; }
    }
}
