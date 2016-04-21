using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Common;
using VehiclesProject.DAL;
using VehiclesProject.Model.Common;
using VehiclesProject.Repository;
using VehiclesProject.Repository.Common;
using VehiclesProject.Service.Common;

namespace VehiclesProject.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        #region Fields
        
        private IVehicleMakeRepository vehicleMakeRepository;

        #endregion Fields

        #region Constructors

        public VehicleMakeService()
        {
            this.vehicleMakeRepository = new VehicleMakeRepository();
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
            return vehicleMakeRepository.GetMakes(filter, paging, sorting);
        }

        /// <summary>
        /// Gets a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includedModel"></param>
        /// <returns> A single VehicleMake entity. </returns>
        public IVehicleMake GetSingleMake(Guid id, string includedModel)
        {
            return vehicleMakeRepository.GetSingleMake(id, includedModel);
        }

        /// <summary>
        /// Creates new VehicleMake entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Create(IVehicleMake model)
        {
            vehicleMakeRepository.Create(model);
        }

        /// <summary>
        /// Updates a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        public void Update(Guid id, IVehicleMake updatedItem)
        {
            vehicleMakeRepository.Update(id, updatedItem);        
        }

        /// <summary>
        /// Deletes a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(Guid id)
        {
            vehicleMakeRepository.Delete(id);
        }

        /// <summary>
        /// Gets a number of all VehicleMake entities.
        /// </summary>
        /// <returns> Number of makes. </returns>
        public int GetItemNum()
        {
            return vehicleMakeRepository.GetItemNum();
        }

        #endregion Methods
    }
}
