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

         IVehicleModel GetSingleModel(Guid? id, string includedModel);
         void Create(IVehicleModel model, Guid? id);
         void Update(Guid? id, IVehicleModel updatedItem);
         void Delete(Guid? id);
    }
}
