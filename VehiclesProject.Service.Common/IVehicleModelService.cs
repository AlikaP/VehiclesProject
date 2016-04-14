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
    public interface IVehicleModelService
    {
        IPagedList<IVehicleModel> GetModels(Guid makeId, IFiltering filter, IPaging paging, ISorting sorting);
        IVehicleModel GetSingleModel(Guid id, string includedModel);
        void Create(IVehicleModel model, Guid id);
        void Update(Guid id, IVehicleModel updatedItem);
        void Delete(Guid id);
        int GetModelNum(Guid id);
    }
}
