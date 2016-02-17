using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Common
{
    public interface IFiltering
    {
        string SearchString { get; set; }

        //IQueryable<VehicleMake> SearchMake(VehicleContext context, string searchString);

        //string GetFilter(string searchString, string currentFilter);
    }
}
