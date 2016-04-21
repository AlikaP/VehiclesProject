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
        #region Fields

        private IGenericRepository genericRepository;

        #endregion Fields

        #region Constructors

        public VehicleMakeRepository()
        {
            this.genericRepository = new GenericRepository();    
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets paged list of all VehicleMakes.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="paging"></param>
        /// <param name="sorting"></param>
        /// <returns> A paged list of makes. </returns>
        public IPagedList<IVehicleMake> GetMakes(IFiltering filter, IPaging paging, ISorting sorting)
        {
            // Gets the search input.
            var searchString = filter.SearchString;

            // Gets the number and size of a page.
            int pageNumber = paging.PageNumber;
            int pageSize = paging.PageSize;
            
            // Gets the VehicleMakes by search string
            var vehicleMakes = genericRepository.GetSet<VehicleMake>();

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(m => m.Name == searchString
                                        || m.Abrev == searchString
                                        || m.VehicleModels.Count(s => s.Name == searchString) > 0);
            }

            // Sorts the filtered list of makes.
            var sortedModel = vehicleMakes.OrderBy(sorting.Sorters.FirstOrDefault().GetSortExpression()).Select(m=>m);

            // Gets the paged list by parameters and maps it to corresponding type.
            var pagedList = genericRepository.GetPagedList(sortedModel, pageSize, pageNumber);
                        
            IEnumerable<VehicleMakePoco> sourceList = Mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakePoco>>(pagedList);

            return new StaticPagedList<VehicleMakePoco>(sourceList, pagedList.GetMetaData());
            
        }

        /// <summary>
        /// Gets a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includedModel"></param>
        /// <returns> A single VehicleMake entity. </returns>
        public IVehicleMake GetSingleMake(Guid id, string includedModel)
        {                        
            return Mapper.Map<VehicleMakePoco>(genericRepository.GetSet<VehicleMake>().SingleOrDefault(item => item.Id == id));           
        }

        /// <summary>
        /// Creates new VehicleMake entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Create(IVehicleMake model)
        {
            genericRepository.Create(Mapper.Map<VehicleMake>(model));
        }

        /// <summary>
        /// Updates a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        public void Update(Guid id, IVehicleMake updatedItem)
        {
            var item = genericRepository.GetSet<VehicleMake>().SingleOrDefault(p => p.Id == id);

            genericRepository.Update(item, Mapper.Map<VehicleMake>(updatedItem));
        }

        /// <summary>
        /// Deletes a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(Guid id)
        {
            var model = genericRepository.GetSet<VehicleMake>().SingleOrDefault(p => p.Id == id);  
            
            genericRepository.Delete(Mapper.Map<VehicleMake>(model));  
        }

        /// <summary>
        /// Gets a number of all VehicleMake entities.
        /// </summary>
        /// <returns> Number of makes. </returns>
        public int GetItemNum()
        {
            return genericRepository.GetSet<VehicleMake>().Count();
        }

        #endregion Methods
    }
}