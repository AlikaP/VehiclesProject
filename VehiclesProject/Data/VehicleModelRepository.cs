using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VehiclesProject.Models;

namespace VehiclesProject.Data
{
    public class VehicleModelRepository  : IVehicleModelRepository
    {
              
        private VehicleContext context;
        private IGenericRepository genericRepository;

        public VehicleModelRepository(VehicleContext context)
        {
            this.context = context;
            this.genericRepository = new GenericRepository(context);
        }

        public VehicleModel GetSingleModel(int? id, string includedModel)
        {
            if (includedModel != null)
            {
                var model = context.VehicleModels.Include(includedModel);
                return model.SingleOrDefault(item => item.Id == id);
            }
            else
            {
                return context.VehicleModels.SingleOrDefault(item => item.Id == id);
            }
        }

        public void Create(VehicleModel model, int? id)
        {
            
            var make = context.VehicleMakes.Find(id);
            model.MakeId = make.Id;

            genericRepository.Create(model);

        }

        public void Edit(int? id, VehicleModel updatedItem)
        {
            var item = context.VehicleModels.SingleOrDefault(p => p.Id == id);

            genericRepository.Edit(item, updatedItem);
        }

        public void Delete(int? id)
        {
            var model = context.VehicleModels.SingleOrDefault(p => p.Id == id); 
            
            genericRepository.Delete(model);            
        }
        


    }
}