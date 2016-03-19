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

        public IVehicleModel GetSingleModel(int? id, string includedModel)
        {
            try
            {
                return vehicleModelRepository.GetSingleModel(id, includedModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Create(IVehicleModel model, int? id)
        {
            try
            {
                vehicleModelRepository.Create(model, id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Edit(int? id, IVehicleModel updatedItem)
        {
            try
            {
                vehicleModelRepository.Edit(id, updatedItem);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int? id)
        {
            try
            {
                vehicleModelRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
