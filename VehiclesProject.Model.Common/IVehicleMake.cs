using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Model.Common
{
    public interface IVehicleMake
    {
        #region Properites

        /// <summary>
        /// Gets or sets the vehicle make identifier.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the vehicle make.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbrevation of the vehicle make's name.
        /// </summary>
        string Abrev { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to all dependant vehicle models.
        /// </summary>
        ICollection<IVehicleModel> VehicleModels { get; set; }

        #endregion Properites
    }
}
