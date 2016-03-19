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
            try
            {
                return vehicleMakeRepository.GetMakes(filter, paging, sorting);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IVehicleMake GetSingleMake(int? id, string includedModel, IFiltering filter)
        {
            try
            {
                return vehicleMakeRepository.GetSingleMake(id, includedModel, filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Create(IVehicleMake model)
        {
            try
            {
                vehicleMakeRepository.Create(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Edit(int? id, IVehicleMake updatedItem)
        {
            try
            {
                vehicleMakeRepository.Edit(id, updatedItem);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int? id)
        {
            try
            {
                vehicleMakeRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetItemNum()
        {
            try
            {
                return vehicleMakeRepository.GetItemNum();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetModelNum(int? id)
        {
            try
            {
                return vehicleMakeRepository.GetModelNum(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
