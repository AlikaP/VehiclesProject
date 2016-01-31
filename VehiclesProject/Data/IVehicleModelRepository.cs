using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehiclesProject.Models;

namespace VehiclesProject.Data
{
    public interface IVehicleModelRepository
    {
        //create overload
        //void Create(VehicleModel model, int? id);

         VehicleModel GetSingleModel(int? id, string includedModel);
         void Create(VehicleModel model, int? id);
         void Edit(int? id, VehicleModel updatedItem);
         void Delete(int? id);

    }
}
