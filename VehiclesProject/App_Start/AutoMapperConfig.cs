using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehiclesProject.DAL.Entities;
using VehiclesProject.Model;
using VehiclesProject.Model.Common;
//using VehiclesProject.Model;

namespace VehiclesProject.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Initializes the all AutoMapper maps 
            VehiclesProject.Model.Mapping.AutoMapperMaps.Initialize();               
        }
    }
}