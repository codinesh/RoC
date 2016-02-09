using Microsoft.AspNet.Mvc.Rendering;
using RideOnCab.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RideOnCab.ViewModels
{
    public class CabViewModel : Cab
    {
        public CabViewModel()
        {
        }
        public int SelectedVehicleId { get; set; }

        [Display(Name ="Vehicle Model")]
        public List<Vehicle> AvailableVehicles { get; set; }
        public IList<SelectListItem> AvailableVehicles1 { get; set; } = new List<SelectListItem>();
    }
}