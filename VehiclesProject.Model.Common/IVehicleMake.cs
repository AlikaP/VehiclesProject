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
         int Id { get; set; }
         string Name { get; set; }
         string Abrev { get; set; }
        ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}
