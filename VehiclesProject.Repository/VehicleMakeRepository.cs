using System;
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

        private VehicleContext context = new VehicleContext();

        public VehicleMakeRepository()
        {
            this.genericRepository = new GenericRepository(context);    
        }
        
        public IPagedList<IVehicleMake> GetMakes(IFiltering filter, IPaging paging, ISorting sorting)
        {
            try
            {
                //IFiltering filter = new Filtering(currentFilter, searchString);
                var searchString = filter.SearchString;
                //int pageSize = 5;

                //IPaging paging = new Paging(page, pageSize);
                int pageNumber = paging.PageNumber;
                int pageSize = paging.PageSize;
            
                //
                var vehicleMakes = from m in context.VehicleMakes select m;

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
            catch (Exception e)
            {
                throw e;
            }
        }

        public IVehicleMake GetSingleMake(int? id, string includedModel, IFiltering filter)
        {
            try
            {
                if (includedModel != null)
                {
                    var searchString = filter.SearchString;
                                                
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        context.Configuration.LazyLoadingEnabled = false;

                        var vehicleMake = context.VehicleMakes.Select(m => m).Where(f => f.Id == id).SingleOrDefault();
                        //var vehicleMake = context.VehicleMakes.Select(m => m).Where(f => f.Id == id).Where(m => m.VehicleModels.Count(s => s.Name == searchString) > 0).SingleOrDefault();

                        if (vehicleMake != null)
                        {                       
                            context.Entry(vehicleMake)
                            .Collection(includedModel)
                            .Query()
                            .Where("Name=@0", searchString).Load();

                            return Mapper.Map<VehicleMakePoco>(vehicleMake);
                        }
                        else if (vehicleMake == null)
                        {   
                            return Mapper.Map<VehicleMakePoco>(context.VehicleMakes.SingleOrDefault(item => item.Id == id));
                        }
                    }

                    return Mapper.Map<VehicleMakePoco>(context.VehicleMakes.Include(includedModel).SingleOrDefault(item => item.Id == id));              
                }
                else
                {              
                    return Mapper.Map<VehicleMakePoco>(context.VehicleMakes.SingleOrDefault(item => item.Id == id)); 
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Create(IVehicleMake model)
        {
            try
            {
                genericRepository.Create(Mapper.Map<VehicleMake>(model));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Edit(int? id, IVehicleMake updatedItem)
        {
            try
            {
                var item = context.VehicleMakes.SingleOrDefault(p => p.Id == id);

                genericRepository.Edit(item, Mapper.Map<VehicleMake>(updatedItem));
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
                var model = context.VehicleMakes.SingleOrDefault(p => p.Id == id);  

                //context.VehicleModels.RemoveRange(context.VehicleModels.Where(x => x.MakeId == model.Id));
            
                genericRepository.Delete(Mapper.Map<VehicleMake>(model));  //genericRepository.Delete<VehicleMake>(model);  ---> simplified    
            }
            catch (Exception e)
            {
                throw e;
            }
        }
              
        public int GetItemNum()
        {
            try
            {
                return context.VehicleMakes.Count();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetModelNum(int? id)
        {
            try
            {
                //context.Configuration.LazyLoadingEnabled = false;

                var vehicleMakes = context.VehicleMakes.Select(m => m).Where(f => f.Id == id).SingleOrDefault();
                var modelCount = context.Entry(vehicleMakes).Collection("VehicleModels").Query().Count();

                //return context.VehicleModels.Where(p => p.MakeId == id).Count();

                //return vehicleMakes.VehicleModels.Count(); //filtered number

                return modelCount;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}