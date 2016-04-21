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
        #region Fields

        private IGenericRepository genericRepository;

        #endregion Fields

        #region Constructors

        public VehicleModelRepository()
        {
            this.genericRepository = new GenericRepository();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets paged list of all VehicleModels.
        /// </summary>
        /// <param name="makeId"></param>
        /// <param name="filter"></param>
        /// <param name="paging"></param>
        /// <param name="sorting"></param>
        /// <returns> Paged list of all VehicleModels. </returns>
        public IPagedList<IVehicleModel> GetModels(Guid makeId, IFiltering filter, IPaging paging, ISorting sorting)
        {
            // Gets the search input.
            var searchString = filter.SearchString;
            
            // Gets the number and size of a page.
            int pageNumber = paging.PageNumber;
            int pageSize = paging.PageSize;
            
            // Gets the specific models of the make, conditioned by search string.
            var vehicleModels = genericRepository.GetSet<VehicleModel>().Where(m => m.MakeId == makeId);

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleModels = vehicleModels.Where(m => m.Name == searchString
                                        || m.Abrev == searchString);
            }

            // Sorts the filtered list of models.
            var sortedModel = vehicleModels.OrderBy(sorting.Sorters.FirstOrDefault().GetSortExpression());

            // Gets the paged list by parameters and maps it to corresponding type.
            var pagedList = genericRepository.GetPagedList(sortedModel, pageSize, pageNumber);

            IEnumerable<VehicleModelPoco> sourceList = Mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelPoco>>(pagedList);

            return new StaticPagedList<VehicleModelPoco>(sourceList, pagedList.GetMetaData());
        }

        /// <summary>
        /// Gets a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includedModel"></param>
        /// <returns> A VehicleModel entity. </returns>
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

        /// <summary>
        /// Creates new VehicleModel entity.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Create(IVehicleModel model, Guid id)
        {
            var make = genericRepository.GetContext().VehicleMakes.Find(id);
            model.MakeId = make.Id;

            genericRepository.Create(Mapper.Map<VehicleModel>(model));
        }

        /// <summary>
        /// Updates a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        public void Update(Guid id, IVehicleModel updatedItem)
        {
            var item = genericRepository.GetSet<VehicleModel>().SingleOrDefault(p => p.Id == id);

            // Sets the corresponding foreign key.
            var make = genericRepository.GetContext().VehicleMakes.Find(id);
            updatedItem.MakeId = item.MakeId;

            genericRepository.Update(item, Mapper.Map<VehicleModel>(updatedItem));          
        }

        /// <summary>
        /// Deletes a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(Guid id)
        {
            var model = genericRepository.GetSet<VehicleModel>().SingleOrDefault(p => p.Id == id); 
            
            genericRepository.Delete(Mapper.Map<VehicleModel>(model));
        }

        /// <summary>
        /// Gets a number of all VehicleModel entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Number of models for a specific make. </returns>
        public int GetModelNum(Guid id)
        {
            var modelCount = genericRepository.GetSet<VehicleModel>().Where(m => m.MakeId == id).Count();
            
            return modelCount;
        }

        #endregion Methods
    }
}