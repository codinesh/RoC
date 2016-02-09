using Microsoft.AspNet.Mvc.Rendering;
using RideOnCab.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RideOnCab.ViewModels
{
    public class RideViewModel : Ride
    {
        public RideViewModel()
        {
        }

        public RideViewModel(IList<SelectListItem> availableVehicles1)
        {
            AvailableVehicles1 = availableVehicles1;
        }

        //public Ride Ride { get; set; }
        public int SelectedVehicleId { get; set; }

        [Display(Name = "Vehicle Model")]
        public List<Vehicle> AvailableVehicles { get; set; }
        public IList<SelectListItem> AvailableVehicles1 { get; set; } = new List<SelectListItem>();
    }
}