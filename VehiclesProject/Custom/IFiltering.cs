using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Models;
using VehiclesProject.Data;

namespace VehiclesProject.Custom
{
    public interface IFiltering
    {
       IQueryable<VehicleMake> SearchMake(VehicleContext context, string searchString);
    }
}
