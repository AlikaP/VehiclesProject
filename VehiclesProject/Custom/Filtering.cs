using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehiclesProject.Models;
using VehiclesProject.Data;

namespace VehiclesProject.Custom
{
    public class Filtering : IFiltering
    {
        
        public string GetFilter(string searchString, string currentFilter)
        {
           
            if(searchString == null)
            {
                searchString = currentFilter;
            }
            
            return searchString;
        }

    }
}