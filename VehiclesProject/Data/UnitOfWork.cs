using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VehiclesProject.Models;

namespace VehiclesProject.Data
{
    public class UnitOfWork //: IDisposable
    {
        private VehicleContext context = new VehicleContext();
        private IVehicleModelRepository vehicleModelRepository;
        private IVehicleMakeRepository vehicleMakeRepository;

        //public IVehicleMakeRepository VehicleMakeRepository
        //{
        //    get
        //    {

        //        if (this.vehicleMakeRepository == null)
        //        {
        //            this.vehicleMakeRepository = new VehicleMakeRepository(context);
        //        }
        //        return vehicleMakeRepository;
        //    }
        //}

        //public IVehicleModelRepository VehicleModelRepository
        //{
        //    get
        //    {

        //        if (this.vehicleModelRepository == null)
        //        {
        //            this.vehicleModelRepository = new VehicleModelRepository(context);
        //        }
        //        return vehicleModelRepository;
        //    }
        //}







        //public GenericRepository<VehicleModel> VehicleModelRepository
        //{
        //    get
        //    {

        //        if (this.vehicleModelRepository == null)
        //        {
        //            this.vehicleModelRepository = new GenericRepository<VehicleModel>(context);
        //        }
        //        return vehicleModelRepository;
        //    }
        //}


        //................................

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose(); //end
        //        }
        //    }
        //    this.disposed = true;
        //}

        


    }
}