using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehiclesProject.Models;
using PagedList;

namespace VehiclesProject.Data
{
    public interface IVehicleMakeRepository
    {
         IPagedList<VehicleMake> GetMakes(string currentFilter, string searchString, int? page);
         VehicleMake GetSingleMake(int? id, string includedModel);
         void Create(VehicleMake model);
         void Edit(int? id, VehicleMake updatedItem);
         void Delete(int? id);
        int GetItemNum();

    }
}
