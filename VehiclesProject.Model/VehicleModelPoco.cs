using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Model
{
    public class VehicleModelPoco : IVehicleModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }   //foreign key name = <navigation property name><primary key property name>

        [Display(Name = "Model Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Model Abbrevation")]
        [Required]
        public string Abrev { get; set; }
        
        public virtual IVehicleMake Make { get; set; }         //MakeId
    }
}