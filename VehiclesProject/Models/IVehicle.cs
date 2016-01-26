using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Models
{
    public interface IVehicle
    {
         int Id { get; set; }
         string Name { get; set; }
         string Abrev { get; set; }
    }
}
