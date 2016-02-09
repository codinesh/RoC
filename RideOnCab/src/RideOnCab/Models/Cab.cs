using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RideOnCab.Models
{
    public class Cab
    {
        public int Id { get; set; }
        [Display(Name ="Registration Number")]
        public string RegistrationNumber { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Vehicle Vehicle { get; set; }
    }

}
