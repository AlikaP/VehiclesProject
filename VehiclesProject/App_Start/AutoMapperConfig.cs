using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VehiclesProject.Models;

namespace VehiclesProject.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
           
            AutoMapper.Mapper.CreateMap<VehicleMake, VehicleMake>().ForMember(dest => dest.VehicleModels, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<VehicleModel, VehicleModel>().ForMember(dest => dest.MakeId, opt => opt.Ignore()).ForMember(dest => dest.Make, opt => opt.Ignore());

        }
    }
}