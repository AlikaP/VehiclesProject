using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

using VehiclesProject.Models;
using System.Data.Entity;
using VehiclesProject.Custom;

using PagedList;

namespace VehiclesProject.Data
{
    public class GenericRepository  : IGenericRepository  
    {

        private VehicleContext context;

        public GenericRepository(VehicleContext context)
        {
            this.context = context;
           
        }

        public virtual IPagedList<T> GetPagedList<T>(IOrderedQueryable<T> model, int pageSize, int pageNumber) where T : class //, IVehicle
        {           
            
             return model.ToPagedList(pageNumber, pageSize); //filteredModel.OrderBy(m => m.Name).ToPagedList(pageNumber, pageSize);
                                      
        }

       
        public virtual void Edit<T>(T item, T updatedItem) where T : class
        {
                          
             Mapper.Map(updatedItem, item);            
             context.SaveChanges();
            
        }

        public virtual void Create<T>(T model) where T : class
        {
                       
             context.Set<T>().Add(model);
             context.SaveChanges();                
            
        }


        public virtual void Delete<T>(T item) where T : class
        {
          
              context.Set<T>().Remove(item);
              context.SaveChanges();
            
        }
    }
}