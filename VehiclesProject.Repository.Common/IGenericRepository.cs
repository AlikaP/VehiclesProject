using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.DAL;
using VehiclesProject.DAL.Entities;
using VehiclesProject.Model;

namespace VehiclesProject.Repository.Common
{
    public interface IGenericRepository 
    {
        #region Methods

        /// <summary>
        /// Gets paged list of all entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns> Paged list of all VehicleModels. </returns>
        IPagedList<T> GetPagedList<T>(IQueryable<T> model, int pageSize, int pageNumber) where T : class;

        /// <summary>
        /// Updates a single entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        void Update<T>(T item,T updatedItem) where T : class;

        /// <summary>
        /// Creates new entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        void Create<T>(T model) where T : class;

        /// <summary>
        /// Deletes a single entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        void Delete<T>(T item) where T : class;

        /// <summary>
        /// Gets a database set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns> Database set. </returns>
        IQueryable<T> GetSet<T>() where T : class;

        /// <summary>
        /// Gets application Context.
        /// </summary>
        /// <returns> Context. </returns>
        VehicleContext GetContext();

        #endregion Methods
    }
}
