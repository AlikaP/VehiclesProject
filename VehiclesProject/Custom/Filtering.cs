using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehiclesProject.Models;
using VehiclesProject.Data;

namespace VehiclesProject.Custom
{
    public abstract class Filtering : IFiltering
    {
        protected string searchString;
        protected string currentFilter;

       

        //public IQueryable<VehicleMake> SearchMake(VehicleContext context, string searchString)
        //{
            


            //var vehicleMakes = from m in context.VehicleMakes select m;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    vehicleMakes = vehicleMakes.Where(m => m.Name == searchString
            //                           || m.Abrev == searchString
            //                           || m.VehicleModels.Count(s => s.Name == searchString) > 0);
            //}

            //return vehicleMakes;

        //}
    }
}