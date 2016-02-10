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
        public string SearchString{get; set;}

        public Filtering(string currentFilter, string searchString)
        {
            if (searchString == null)
            {
                this.SearchString = currentFilter;
            }
            else
                this.SearchString = searchString;
        }

        //public string GetFilter(string searchString, string currentFilter)
        //{

        //    if(searchString == null)
        //    {
        //        searchString = currentFilter;
        //    }

        //    return searchString;
        //}

    }
}