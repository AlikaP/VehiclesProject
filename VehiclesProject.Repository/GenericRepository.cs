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
        private VehicleContext context;

        public GenericRepository(VehicleContext context)
        {
            this.context = context;      
        }

        public virtual IPagedList<T> GetPagedList<T>(List<T> model, int pageSize, int pageNumber) where T : class //, IVehicle
        {
            try
            {
                return model.ToPagedList(pageNumber, pageSize); //filteredModel.OrderBy(m => m.Name).ToPagedList(pageNumber, pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       
        public virtual void Edit<T>(T item, T updatedItem) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = context.Entry(updatedItem);
            
                if(item != null)
                {
                    context.Entry(item).State = EntityState.Detached;
                }
                dbEntityEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Create<T>(T model) where T : class
        {
            try
            {
                context.Set<T>().Add(model);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Delete<T>(T item) where T : class
        {
            try
            {
                context.Set<T>().Remove(item);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}