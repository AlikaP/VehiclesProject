using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.DAL.Entities
{
    public class VehicleModel
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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbrevation of the vehicle model's name.
        /// </summary>
        public string Abrev { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to dependant vehicle make.
        /// </summary>
        public virtual VehicleMake Make { get; set; }

        #endregion Properites
    }
}
