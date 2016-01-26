using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehiclesProject.Models
{
    public class VehicleMake : IVehicle
    {
        
        public int Id { get; set; }

        [Display(Name = "Make Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Make Abbrevation")]
        [Required]
        public string Abrev { get; set; }

        [Display(Name = "Models")]
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }

    }
}