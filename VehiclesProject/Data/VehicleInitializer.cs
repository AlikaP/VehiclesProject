using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VehiclesProject.Models;

namespace VehiclesProject.Data
{
    public class VehicleInitializer : System.Data.Entity.DropCreateDatabaseAlways<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {         

            var vehicleMakes = new List<VehicleMake>
            {
                new VehicleMake{Name="Audi",Abrev="AUDI"},
                new VehicleMake{Name="BMW",Abrev="BMW"},
                new VehicleMake{Name="Chevrolet",Abrev="CHEW"},
                new VehicleMake{Name="Ford",Abrev="FORD"},
                new VehicleMake{Name="Buick",Abrev="BUIC"},
                new VehicleMake{Name="Cadillac",Abrev="CADI"},
                new VehicleMake{Name="Renault",Abrev="RENA"},
                new VehicleMake{Name="Corvette",Abrev="CHEV"},
                new VehicleMake{Name="Nissan",Abrev="NISS"},
                new VehicleMake{Name="Kaiser",Abrev="KAIS"}

            };

            vehicleMakes.ForEach(s => context.VehicleMakes.Add(s));
            context.SaveChanges();


            var vehicleModels = new List<VehicleModel>
            {
                new VehicleModel{MakeId=1,Name="031",Abrev="Super90"},
                new VehicleModel{MakeId=1,Name="032",Abrev="100"},
                new VehicleModel{MakeId=1,Name="033",Abrev="Fox"},
                new VehicleModel{MakeId=2,Name="034",Abrev="3-series"},
                new VehicleModel{MakeId=2,Name="035",Abrev="5-series"},
                new VehicleModel{MakeId=3,Name="004",Abrev="Corvette"},
                new VehicleModel{MakeId=3,Name="006",Abrev="Corvair"},
                new VehicleModel{MakeId=4,Name="001",Abrev="Falcon"},
                new VehicleModel{MakeId=4,Name="002",Abrev="Fairlane"},
                new VehicleModel{MakeId=5,Name="007",Abrev="Century"}

            };
            vehicleModels.ForEach(s => context.VehicleModels.Add(s));
            context.SaveChanges();

            

        }
    }
}