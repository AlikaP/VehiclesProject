using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.DAL.Entities
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }   //foreign key name = <navigation property name><primary key property name>

        public string Name { get; set; }

        public string Abrev { get; set; }

        public virtual VehicleMake Make { get; set; }         //MakeId
    }
}
