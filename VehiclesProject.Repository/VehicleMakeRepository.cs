﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;
using VehiclesProject.Model;
using AutoMapper;
using PagedList;
using System.Data.Entity;
using VehiclesProject.Repository.Common;
using VehiclesProject.Common;
using VehiclesProject.DAL;
using VehiclesProject.Model.Common;
using VehiclesProject.DAL.Entities;

namespace VehiclesProject.Repository
{
    public class VehicleMakeRepository :  IVehicleMakeRepository
    {      
        private IGenericRepository genericRepository;

        //private VehicleContext context = new VehicleContext();

        public VehicleMakeRepository()
        {
            this.genericRepository = new GenericRepository();    
        }
        
        public IPagedList<IVehicleMake> GetMakes(IFiltering filter, IPaging paging, ISorting sorting)
        {
            //IFiltering filter = new Filtering(currentFilter, searchString);
            var searchString = filter.SearchString;
            //int pageSize = 5;

            //IPaging paging = new Paging(page, pageSize);
            int pageNumber = paging.PageNumber;
            int pageSize = paging.PageSize;
            
            //
            var vehicleMakes = from m in genericRepository.GetSet<VehicleMake>() select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(m => m.Name == searchString
                                        || m.Abrev == searchString
                                        || m.VehicleModels.Count(s => s.Name == searchString) > 0);
            }
                        
            //
            var sortedModel = Mapper.Map<List<VehicleMakePoco>>(vehicleMakes.OrderBy(sorting.Sorters.FirstOrDefault().GetSortExpression()).ToList());
 
            //IPaging paging = new Paging();
            //var pagination = paging.SetPagination(currentFilter, searchString, page);
            //searchString = pagination.Item1;
            //int pageNumber = pagination.Item2;

            //IFiltering filter = new Filtering();
            //var filteredModel = filter.SearchMake(context, searchString);

            //ISorting sort = new Sorting();
            //var model = sort.SortingBy(filteredModel, "asc", m => m.Name);

            return genericRepository.GetPagedList(sortedModel, pageSize, pageNumber);
        }

        public IVehicleMake GetSingleMake(Guid id, string includedModel)
        {
            //if (includedModel != null)
            //{
            //    var searchString = filter.SearchString;

            //    int pageNumber = paging.PageNumber;
            //    int pageSize = paging.PageSize;

            //    if (!String.IsNullOrEmpty(searchString))
            //    {
            //        genericRepository.GetContext().Configuration.LazyLoadingEnabled = false;

            //        var vehicleMake = genericRepository.GetSet<VehicleMake>().Select(m => m).Where(f => f.Id == id).SingleOrDefault();  
            //        //var vehicleMake = context.VehicleMakes.Select(m => m).Where(f => f.Id == id).Where(m => m.VehicleModels.Count(s => s.Name == searchString) > 0).SingleOrDefault();

            //        if (vehicleMake != null)
            //        {
            //            // Explicit loading of VehicleModel collection.
            //            genericRepository.GetContext().Entry(vehicleMake)
            //            .Collection(includedModel)
            //            .Query()
            //            .Where("Name=@0", searchString).Load();
                                                
            //            var vehMake = Mapper.Map<VehicleMakePoco>(vehicleMake);

            //            //var vm = vehMake.VehicleModels.ToList();

            //            //var a = genericRepository.GetPagedList(vm, pageSize, pageNumber);

            //            vehMake.VehicleModels = vehMake.VehicleModels.ToPagedList(pageNumber, pageSize);

            //            return vehMake;
            //        }
            //        else if (vehicleMake == null)
            //        {   
            //            return Mapper.Map<VehicleMakePoco>(genericRepository.GetSet<VehicleMake>().SingleOrDefault(item => item.Id == id));
            //        }
            //    }
            //    return Mapper.Map<VehicleMakePoco>(genericRepository.GetSet<VehicleMake>().Include(includedModel).SingleOrDefault(item => item.Id == id));              
            //}
            //else
            //{              
                return Mapper.Map<VehicleMakePoco>(genericRepository.GetSet<VehicleMake>().SingleOrDefault(item => item.Id == id)); 
            //}
        }

        public void Create(IVehicleMake model)
        {
            genericRepository.Create(Mapper.Map<VehicleMake>(model));
        }

        public void Update(Guid id, IVehicleMake updatedItem)
        {
            var item = genericRepository.GetSet<VehicleMake>().SingleOrDefault(p => p.Id == id);

            genericRepository.Update(item, Mapper.Map<VehicleMake>(updatedItem));
        }

        public void Delete(Guid id)
        {
            var model = genericRepository.GetSet<VehicleMake>().SingleOrDefault(p => p.Id == id);  

            //context.VehicleModels.RemoveRange(context.VehicleModels.Where(x => x.MakeId == model.Id));
            
            genericRepository.Delete(Mapper.Map<VehicleMake>(model));  //genericRepository.Delete<VehicleMake>(model);  ---> simplified    
        }
              
        public int GetItemNum()
        {
            return genericRepository.GetSet<VehicleMake>().Count();
        }

        //public int GetModelNum(Guid id)
        //{
        //    //context.Configuration.LazyLoadingEnabled = false;

        //    var vehicleMakes = genericRepository.GetSet<VehicleMake>().Select(m => m).Where(f => f.Id == id).SingleOrDefault();
        //    var modelCount = genericRepository.GetContext().Entry(vehicleMakes).Collection("VehicleModels").Query().Count();

        //    //return context.VehicleModels.Where(p => p.MakeId == id).Count();

        //    //return vehicleMakes.VehicleModels.Count(); //filtered number

        //    return modelCount;
        //}
    }
}