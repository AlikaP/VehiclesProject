using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehiclesProject.Model;
using PagedList;
using VehiclesProject.Common;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        #region Methods

        /// <summary>
        /// Gets paged list of all VehicleMakes.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="paging"></param>
        /// <param name="sorting"></param>
        /// <returns> A paged list of makes. </returns>
        IPagedList<IVehicleMake> GetMakes(IFiltering filter, IPaging paging, ISorting sorting);

        /// <summary>
        /// Gets a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includedModel"></param>
        /// <returns> A single VehicleMake entity. </returns>
        IVehicleMake GetSingleMake(Guid id, string includedModel);

        /// <summary>
        /// Creates new VehicleMake entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Create(IVehicleMake model);

        /// <summary>
        /// Updates a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        void Update(Guid id, IVehicleMake updatedItem);

        /// <summary>
        /// Deletes a single VehicleMake entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(Guid id);

        /// <summary>
        /// Gets a number of all VehicleMake entities.
        /// </summary>
        /// <returns> Number of makes. </returns>
        int GetItemNum();

        #endregion Methods
    }
}
