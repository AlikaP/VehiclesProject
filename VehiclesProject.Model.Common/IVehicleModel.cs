using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Model.Common
{
    public interface IVehicleModel
    {
         int Id { get; set; }
         int MakeId { get; set; }        
         string Name { get; set; }
         string Abrev { get; set; }
         IVehicleMake Make { get; set; }       
    }
}
