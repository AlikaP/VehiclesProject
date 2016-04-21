using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.DAL.Entities
{
    public class VehicleMake
    {
        #region Properites

        /// <summary>
        /// Gets or sets the vehicle make identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the vehicle make.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbrevation of the vehicle make's name.
        /// </summary>
        public string Abrev { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to all dependant vehicle models.
        /// </summary>
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }

        #endregion Properites
    }
}
