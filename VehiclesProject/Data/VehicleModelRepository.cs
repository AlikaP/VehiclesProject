using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VehiclesProject.Models;

namespace VehiclesProject.Data
{
    public class VehicleModelRepository : GenericRepository<VehicleContext, VehicleModel>, IVehicleModelRepository
    {
        private VehicleContext context;

        public VehicleModelRepository(VehicleContext context)
        {
            this.context = context;
        }

        public void Create(VehicleModel model, int? id)
        {
            using (context)
            {
                var make = context.VehicleMakes.Find(id);
                model.MakeId = make.Id;

                context.VehicleModels.Add(model);
                context.SaveChanges();

            }
        }

    }
}