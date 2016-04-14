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
using VehiclesProject.Common;
using PagedList;
using System.Linq.Dynamic;

namespace VehiclesProject.Repository
{
    public class VehicleModelRepository  : IVehicleModelRepository
    {       
        //private VehicleContext context;
        private IGenericRepository genericRepository;

        //private VehicleContext context = new VehicleContext();

        public VehicleModelRepository()
        {
            //this.context = context;
            this.genericRepository = new GenericRepository();
        }

        public IPagedList<IVehicleModel> GetModels(Guid makeId, IFiltering filter, IPaging paging, ISorting sorting)
        {
            //IFiltering filter = new Filtering(currentFilter, searchString);
            var searchString = filter.SearchString;
            //int pageSize = 5;

            //IPaging paging = new Paging(page, pageSize);
            int pageNumber = paging.PageNumber;
            int pageSize = paging.PageSize;

            //
            //var vehicleModels = from m in genericRepository.GetSet<VehicleModel>() select m;
            var vehicleModels = genericRepository.GetSet<VehicleModel>().Where(m => m.MakeId == makeId);

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleModels = vehicleModels.Where(m => m.Name == searchString
                                        || m.Abrev == searchString);
            }

            //
            var sortedModel = Mapper.Map<List<VehicleModelPoco>>(vehicleModels.OrderBy(sorting.Sorters.FirstOrDefault().GetSortExpression()).ToList());
            
            return genericRepository.GetPagedList(sortedModel, pageSize, pageNumber);
        }

        public IVehicleModel GetSingleModel(Guid id, string includedModel)
        {
            if (includedModel != null)
            {
                var model = genericRepository.GetContext().VehicleModels.Include(includedModel);
                return Mapper.Map<VehicleModelPoco>(model.SingleOrDefault(item => item.Id == id));
            }
            else
            {
                return Mapper.Map<VehicleModelPoco>(genericRepository.GetSet<VehicleModel>().SingleOrDefault(item => item.Id == id));
            }
        }

        public void Create(IVehicleModel model, Guid id)
        {
            var make = genericRepository.GetContext().VehicleMakes.Find(id);
            model.MakeId = make.Id;

            genericRepository.Create(Mapper.Map<VehicleModel>(model));
        }

        public void Update(Guid id, IVehicleModel updatedItem)
        {
            var item = genericRepository.GetSet<VehicleModel>().SingleOrDefault(p => p.Id == id);

            var make = genericRepository.GetContext().VehicleMakes.Find(id);
            updatedItem.MakeId = item.MakeId;

            genericRepository.Update(item, Mapper.Map<VehicleModel>(updatedItem));          
        }

        public void Delete(Guid id)
        {
            var model = genericRepository.GetSet<VehicleModel>().SingleOrDefault(p => p.Id == id); 
            
            genericRepository.Delete(Mapper.Map<VehicleModel>(model));
        }

        public int GetModelNum(Guid id)
        {
            var modelCount = genericRepository.GetSet<VehicleModel>().Where(m => m.MakeId == id).Count();
            
            return modelCount;
        }
    }
}