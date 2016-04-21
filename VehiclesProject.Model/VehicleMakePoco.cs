using PagedList;
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
        #region Properites

        /// <summary>
        /// Gets or sets the vehicle make identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the vehicle make.
        /// </summary>
        [Display(Name = "Make Name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbrevation of the vehicle make's name.
        /// </summary>
        [Display(Name = "Make Abbrevation")]
        [Required]
        public string Abrev { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to all dependant vehicle models.
        /// </summary>
        [Display(Name = "Models")]
        public virtual ICollection<IVehicleModel> VehicleModels { get; set; }

        #endregion Properites
    }
}