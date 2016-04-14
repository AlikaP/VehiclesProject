using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Common;
using VehiclesProject.DAL;
using VehiclesProject.Model.Common;
using VehiclesProject.Repository;
using VehiclesProject.Repository.Common;
using VehiclesProject.Service.Common;

namespace VehiclesProject.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository vehicleMakeRepository;

        //private VehicleContext context = new VehicleContext();

        public VehicleMakeService()
        {
            this.vehicleMakeRepository = new VehicleMakeRepository();
        }

        public IPagedList<IVehicleMake> GetMakes(IFiltering filter, IPaging paging, ISorting sorting)
        {
            return vehicleMakeRepository.GetMakes(filter, paging, sorting);
        }

        public IVehicleMake GetSingleMake(Guid id, string includedModel)
        {
            return vehicleMakeRepository.GetSingleMake(id, includedModel);
        }

        public void Create(IVehicleMake model)
        {
            vehicleMakeRepository.Create(model);
        }

        public void Update(Guid id, IVehicleMake updatedItem)
        {
            vehicleMakeRepository.Update(id, updatedItem);        
        }

        public void Delete(Guid id)
        {
            vehicleMakeRepository.Delete(id);
        }

        public int GetItemNum()
        {
            return vehicleMakeRepository.GetItemNum();
        }

        //public int GetModelNum(Guid id)
        //{
        //    return vehicleMakeRepository.GetModelNum(id);
        //}
    }
}
