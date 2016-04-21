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
    public class VehicleModelService : IVehicleModelService
    {
        #region Fields

        private IVehicleModelRepository vehicleModelRepository;

        #endregion Fields

        #region Constructors

        public VehicleModelService()
        {
            this.vehicleModelRepository = new VehicleModelRepository();
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
            return vehicleModelRepository.GetModels(makeId, filter, paging, sorting);
        }

        /// <summary>
        /// Gets a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includedModel"></param>
        /// <returns> A single VehicleModel entity. </returns>
        public IVehicleModel GetSingleModel(Guid id, string includedModel)
        {
            return vehicleModelRepository.GetSingleModel(id, includedModel);          
        }

        /// <summary>
        /// Updates a single VehicleModel entity.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Create(IVehicleModel model, Guid id)
        {
            vehicleModelRepository.Create(model, id);          
        }

        /// <summary>
        /// Updates a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        public void Update(Guid id, IVehicleModel updatedItem)
        {
            vehicleModelRepository.Update(id, updatedItem);
        }

        /// <summary>
        /// Deletes a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(Guid id)
        {
            vehicleModelRepository.Delete(id);         
        }

        /// <summary>
        /// Gets a number of all VehicleModel entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetModelNum(Guid id)
        {
            return vehicleModelRepository.GetModelNum(id);
        }

        #endregion Methods
    }
}
