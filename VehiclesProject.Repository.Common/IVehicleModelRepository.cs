using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehiclesProject.Model;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Repository.Common
{
    public interface IVehicleModelRepository
    {
        //create overload
        //void Create(VehicleModel model, int? id);

         IVehicleModel GetSingleModel(int? id, string includedModel);
         void Create(IVehicleModel model, int? id);
         void Edit(int? id, IVehicleModel updatedItem);
         void Delete(int? id);

    }
}
