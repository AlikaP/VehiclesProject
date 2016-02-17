using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VehiclesProject.Model;
using VehiclesProject.DAL;
using VehiclesProject.Repository.Common;
using VehiclesProject.Model.Common;
using AutoMapper;
using VehiclesProject.DAL.Entities;

namespace VehiclesProject.Repository
{
    public class VehicleModelRepository  : IVehicleModelRepository
    {
              
        //private VehicleContext context;
        private IGenericRepository genericRepository;
        private VehicleContext context = new VehicleContext();

        public VehicleModelRepository()
        {
            //this.context = context;
            this.genericRepository = new GenericRepository(context);
        }

        public IVehicleModel GetSingleModel(int? id, string includedModel)
        {
            if (includedModel != null)
            {
                var model = context.VehicleModels.Include(includedModel);
                return Mapper.Map<VehicleModelPoco>(model.SingleOrDefault(item => item.Id == id));
            }
            else
            {
                return Mapper.Map<VehicleModelPoco>(context.VehicleModels.SingleOrDefault(item => item.Id == id));
            }
        }

        public void Create(IVehicleModel model, int? id)
        {
            
            var make = context.VehicleMakes.Find(id);
            model.MakeId = make.Id;

            genericRepository.Create(Mapper.Map < VehicleModel > (model));

        }

        public void Edit(int? id, IVehicleModel updatedItem)
        {
            var item = context.VehicleModels.SingleOrDefault(p => p.Id == id);

            var make = context.VehicleMakes.Find(id);
            updatedItem.MakeId = item.MakeId;

            genericRepository.Edit(item, Mapper.Map < VehicleModel > (updatedItem));
        }

        public void Delete(int? id)
        {
            var model = context.VehicleModels.SingleOrDefault(p => p.Id == id); 
            
            genericRepository.Delete(Mapper.Map < VehicleModel> (model));            
        }
        


    }
}