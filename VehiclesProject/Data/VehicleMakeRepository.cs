using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VehiclesProject.Models;
using VehiclesProject.Custom;

using PagedList;

namespace VehiclesProject.Data
{
    public class VehicleMakeRepository :  IVehicleMakeRepository
    {
       
        private IGenericRepository genericRepository;

        private VehicleContext context = new VehicleContext();

        public VehicleMakeRepository()
        {
            this.genericRepository = new GenericRepository(context);    
        }
        
        public IPagedList<VehicleMake> GetMakes(string currentFilter, string searchString, int? page)
        {
            
            IFiltering filter = new Filtering();
            searchString = filter.GetFilter(currentFilter, searchString);
            
            int pageSize = 5;

            IPaging paging = new Paging();
            int pageNumber = paging.GetPage(page);

           
            //
            var vehicleMakes = from m in context.VehicleMakes select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(m => m.Name == searchString
                                       || m.Abrev == searchString
                                       || m.VehicleModels.Count(s => s.Name == searchString) > 0);
            }


            //
            var sortedModel = vehicleMakes.OrderBy(m => m.Name);
            

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

        public VehicleMake GetSingleMake(int? id, string includedModel)
        {            
            if (includedModel != null)
            {
                var model = context.VehicleMakes.Include(includedModel);
                return model.SingleOrDefault(item => item.Id == id);
            }
            else
            {
                return context.VehicleMakes.SingleOrDefault(item => item.Id == id);
            }
        }

        public void Create(VehicleMake model)
        {
            genericRepository.Create(model);
        }

        public void Edit(int? id, VehicleMake updatedItem)
        {
            var item = context.VehicleMakes.SingleOrDefault(p => p.Id == id);

            genericRepository.Edit(item, updatedItem);
        }

        public void Delete(int? id)
        {
            
            var model = context.VehicleMakes.SingleOrDefault(p => p.Id == id);  

            context.VehicleModels.RemoveRange(context.VehicleModels.Where(x => x.MakeId == model.Id));
            
            genericRepository.Delete(model);  //genericRepository.Delete<VehicleMake>(model);  ---> simplified
                        
        }

      

        public int GetItemNum()
        {
            return context.VehicleMakes.Count();
        }


      

    }
}