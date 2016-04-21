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
        #region Properites

        /// <summary>
        /// Gets or sets the vehicle model identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the vehicle make foreign key.
        /// </summary>
        public Guid MakeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the vehicle model.
        /// </summary>
        [Display(Name = "Model Name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbrevation of the vehicle model's name.
        /// </summary>
        [Display(Name = "Model Abbrevation")]
        [Required]
        public string Abrev { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to dependant vehicle make.
        /// </summary>
        public virtual IVehicleMake Make { get; set; }

        #endregion Properites
    }
}