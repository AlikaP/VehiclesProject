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
            try
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Create(IVehicleModel model, int? id)
        {
            try
            {
                var make = context.VehicleMakes.Find(id);
            model.MakeId = make.Id;

            genericRepository.Create(Mapper.Map<VehicleModel>(model));
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
                var item = context.VehicleModels.SingleOrDefault(p => p.Id == id);

            var make = context.VehicleMakes.Find(id);
            updatedItem.MakeId = item.MakeId;

            genericRepository.Edit(item, Mapper.Map<VehicleModel>(updatedItem));
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
                var model = context.VehicleModels.SingleOrDefault(p => p.Id == id); 
            
            genericRepository.Delete(Mapper.Map<VehicleModel>(model));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}