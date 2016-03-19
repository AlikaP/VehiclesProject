using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Service.Common
{
    public interface IVehicleModelService
    {
        IVehicleModel GetSingleModel(int? id, string includedModel);
        void Create(IVehicleModel model, int? id);
        void Edit(int? id, IVehicleModel updatedItem);
        void Delete(int? id);
    }
}
