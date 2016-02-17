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
         IPagedList<IVehicleMake> GetMakes(IFiltering filter, IPaging paging, ISorting sorting);
        IVehicleMake GetSingleMake(int? id, string includedModel, IFiltering filter);
         void Create(IVehicleMake model);
         void Edit(int? id, IVehicleMake updatedItem);
         void Delete(int? id);
        int GetItemNum();
        int GetModelNum(int? id);

    }
}
