using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Model
{
    public class VehicleMakePoco : IVehicleMake
    {
        
        public int Id { get; set; }

        [Display(Name = "Make Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Make Abbrevation")]
        [Required]
        public string Abrev { get; set; }

        [Display(Name = "Models")]
        public virtual ICollection<IVehicleModel> VehicleModels { get; set; }

    }
}