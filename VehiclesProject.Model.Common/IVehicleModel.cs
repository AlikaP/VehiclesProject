using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Model.Common
{
    public interface IVehicleModel
    {
        /// <summary>
        /// Gets or sets the vehicle model identifier.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the vehicle make foreign key.
        /// </summary>
        Guid MakeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the vehicle model.
        /// </summary>      
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbrevation of the vehicle model's name.
        /// </summary>
        string Abrev { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to dependant vehicle make.
        /// </summary>
        IVehicleMake Make { get; set; }       
    }
}
