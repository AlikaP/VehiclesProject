using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Common;
using VehiclesProject.Model;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Repository.Common
{
    public interface IVehicleModelRepository
    {
        #region Methods

        /// <summary>
        /// Gets paged list of all VehicleModels.
        /// </summary>
        /// <param name="makeId"></param>
        /// <param name="filter"></param>
        /// <param name="paging"></param>
        /// <param name="sorting"></param>
        /// <returns> Paged list of all VehicleModels. </returns>
        IPagedList<IVehicleModel> GetModels(Guid makeId, IFiltering filter, IPaging paging, ISorting sorting);

        /// <summary>
        /// Gets a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includedModel"></param>
        /// <returns> A single VehicleModel entity. </returns>
        IVehicleModel GetSingleModel(Guid id, string includedModel);

        /// <summary>
        /// Updates a single VehicleModel entity.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        void Create(IVehicleModel model, Guid id);

        /// <summary>
        /// Updates a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        void Update(Guid id, IVehicleModel updatedItem);

        /// <summary>
        /// Deletes a single VehicleModel entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(Guid id);

        /// <summary>
        /// Gets a number of all VehicleModel entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Number of models for a specific make. </returns>
        int GetModelNum(Guid id);

        #endregion Methods
    }
}
