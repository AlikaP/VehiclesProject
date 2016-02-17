using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.DAL;
using VehiclesProject.DAL.Entities;
using VehiclesProject.Model.Common;

namespace VehiclesProject.Model.Mapping
{
    public class AutoMapperMaps
    {
        public static void Initialize()
        {
            
            AutoMapper.Mapper.CreateMap<VehicleMake, VehicleMakePoco>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleMake, IVehicleMake>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IVehicleMake, VehicleMakePoco>().ReverseMap();

            AutoMapper.Mapper.CreateMap<VehicleModel, VehicleModelPoco>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IVehicleModel, VehicleModelPoco>().ReverseMap();
        }
    }
}
