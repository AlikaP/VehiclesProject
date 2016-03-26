using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Common;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Service.Common
{
    public interface IVehicleMakeService 
    {
        IPagedList<IVehicleMake> GetMakes(IFiltering filter, IPaging paging, ISorting sorting);
        IVehicleMake GetSingleMake(Guid? id, string includedModel, IFiltering filter);
        void Create(IVehicleMake model);
        void Update(Guid? id, IVehicleMake updatedItem);
        void Delete(Guid? id);
        int GetItemNum();
        int GetModelNum(Guid? id);
    }
}
