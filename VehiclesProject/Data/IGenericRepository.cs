using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Data
{
    public interface IGenericRepository<T> where T : class
    {
        
        T GetSingle(int? id, string property);
        void Edit(int? id, T updatedItem);
        void Create(T model);
        void Delete(int? id);
        IPagedList<T> GetPagedList(IQueryable<T> filteredModel, int pageNumber, int pageSize);
    }
}
