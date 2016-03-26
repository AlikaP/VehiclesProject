using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.DAL;
using VehiclesProject.Model.Common;
using VehiclesProject.Repository;
using VehiclesProject.Repository.Common;
using VehiclesProject.Service.Common;

namespace VehiclesProject.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        //private VehicleContext context;
        private IVehicleModelRepository vehicleModelRepository;

        //private VehicleContext context = new VehicleContext();

        public VehicleModelService()
        {
            //this.context = context;
            this.vehicleModelRepository = new VehicleModelRepository();
        }

        public IVehicleModel GetSingleModel(Guid? id, string includedModel)
        {
            return vehicleModelRepository.GetSingleModel(id, includedModel);          
        }

        public void Create(IVehicleModel model, Guid? id)
        {
            vehicleModelRepository.Create(model, id);          
        }

        public void Update(Guid? id, IVehicleModel updatedItem)
        {
            vehicleModelRepository.Update(id, updatedItem);
        }

        public void Delete(Guid? id)
        {
            vehicleModelRepository.Delete(id);         
        }
    }
}
