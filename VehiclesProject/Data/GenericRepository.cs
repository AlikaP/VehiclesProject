using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

using VehiclesProject.Models;
using System.Data.Entity;

using PagedList;

namespace VehiclesProject.Data
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class, IVehicle 
                                                                          where C : VehicleContext, new()       
    {
        
        //private C context = new C();

        //public C Context
        //{

        //    get { return context; }
        //    set { context = value; }
        //}
        

        public virtual IPagedList<T> GetPagedList(IQueryable<T> filteredModel, int pageNumber, int pageSize)
        {
            using (C context = new C())
            {
                if (filteredModel != null)
                {
                    return filteredModel.OrderBy(m => m.Name).ToPagedList(pageNumber, pageSize);
                }
                else
                    return context.Set<T>()
                    .OrderBy(m => m.Name).ToPagedList(pageNumber, pageSize);
            }
        }

        public virtual T GetSingle(int? id, string includedModel)
        {
            using (C context = new C())
            {
                
                if (includedModel == null)
                {
                    var model = context.Set<T>();
                    return model.SingleOrDefault(item => item.Id == id);
                }
                else
                {
                    var model = context.Set<T>().Include(includedModel);
                    return model.SingleOrDefault(item => item.Id == id);
                }

            }
        }

        public virtual void Edit(int? id, T updatedItem)
        {
            using (C context = new C())
            {
                var item = context.Set<T>().SingleOrDefault(p => p.Id == id);
                
                Mapper.Map(updatedItem, item);
                
                context.SaveChanges();
            }
        }

        public virtual void Create(T model)
        {
            using (C context = new C())
            {            
                context.Set<T>().Add(model);
                context.SaveChanges();                
            }
        }


        public virtual void Delete(int? id)
        {
            using (C context = new C())
            {
                var item = context.Set<T>().SingleOrDefault(p => p.Id == id);

                context.Set<T>().Remove(item);
                context.SaveChanges();
            }
        }
    }
}