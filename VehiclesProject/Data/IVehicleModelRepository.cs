using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehiclesProject.Models;

namespace VehiclesProject.Data
{
    public interface IVehicleModelRepository :  IGenericRepository<VehicleModel>
    {
        //create overload
        void Create(VehicleModel model, int? id);

    }
}
