using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VehiclesProject.Models;

namespace VehiclesProject.Data
{
    public class VehicleMakeRepository : GenericRepository<VehicleContext, VehicleMake>, IVehicleMakeRepository 
    {
        private VehicleContext context;

        public VehicleMakeRepository(VehicleContext context)
        {
            this.context = context;
        }

        public override void Delete(int? id)
        {
            using (context)
            {
                var model = context.VehicleMakes.SingleOrDefault(p => p.Id == id);

                context.VehicleModels.RemoveRange(context.VehicleModels.Where(x => x.MakeId == model.Id));
                context.VehicleMakes.Remove(model);
                context.SaveChanges();
            }
        }



    }
}