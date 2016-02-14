using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehiclesProject.Models;
using PagedList;
using VehiclesProject.Custom;

namespace VehiclesProject.Data
{
    public interface IVehicleMakeRepository
    {
         IPagedList<VehicleMake> GetMakes(IFiltering filter, IPaging paging, ISorting sorting);
        VehicleMake GetSingleMake(int? id, string includedModel, IFiltering filter);
         void Create(VehicleMake model);
         void Edit(int? id, VehicleMake updatedItem);
         void Delete(int? id);
        int GetItemNum();
        int GetModelNum(int? id);

    }
}
