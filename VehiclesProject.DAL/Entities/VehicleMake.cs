using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.DAL.Entities
{
    public class VehicleMake
    {
        public Guid Id { get; set; }
                
        public string Name { get; set; }
                
        public string Abrev { get; set; }

        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
