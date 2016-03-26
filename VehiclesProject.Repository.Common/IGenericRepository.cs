using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.DAL.Entities;
using VehiclesProject.Model;

namespace VehiclesProject.Repository.Common
{
    public interface IGenericRepository //<T> where T : class
    {       
        //T GetSingle<T>(int? id, string property) where T : class;
        void Update<T>(T item,T updatedItem) where T : class;
        void Create<T>(T model) where T : class;
        void Delete<T>(T item) where T : class;
        IPagedList<T> GetPagedList<T>(List<T> model, int pageSize, int pageNumber) where T : class; //, IVehicle;   
    }
}
