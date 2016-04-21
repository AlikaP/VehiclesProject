using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VehiclesProject.Model;
using System.Data.Entity;
using PagedList;
using VehiclesProject.Repository.Common;
using VehiclesProject.DAL;
using VehiclesProject.DAL.Entities;
using System.Data.Entity.Infrastructure;

namespace VehiclesProject.Repository
{
    public class GenericRepository  : IGenericRepository  
    {
        #region Fields
        
        // Creates the new Context object.
        private VehicleContext context = new VehicleContext();

        #endregion Fields


        #region Methods

        /// <summary>
        /// Gets paged list of all entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns> A paged list of elements. </returns>
        public virtual IPagedList<T> GetPagedList<T>(IQueryable<T> model, int pageSize, int pageNumber) where T : class 
        {
            return model.ToPagedList(pageNumber, pageSize);
        }

        /// <summary>
        /// Updates single entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        public virtual void Update<T>(T item, T updatedItem) where T : class
        {
            DbEntityEntry dbEntityEntry = context.Entry(updatedItem);
            
            if(item != null)
            {
                context.Entry(item).State = EntityState.Detached;
            }

            dbEntityEntry.State = EntityState.Modified;
            context.SaveChanges();           
        }

        /// <summary>
        /// Creates new entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void Create<T>(T model) where T : class
        {
            context.Set<T>().Add(model);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes single entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual void Delete<T>(T item) where T : class
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();           
        }

        /// <summary>
        /// Gets a database set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns> Database set. </returns>
        public virtual IQueryable<T> GetSet<T>() where T : class
        {
            return context.Set<T>();
        }

        /// <summary>
        /// Gets application Context.
        /// </summary>
        /// <returns> Context. </returns>
        public virtual VehicleContext GetContext()
        {
            return context;
        }

        #endregion Methods
    }
}