using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehiclesProject.Data;

namespace VehiclesProject.Custom
{
    public class Paging : IPaging
    {
        //public Tuple<string, int> SetPagination(string currentFilter, string searchString, int? page)
        //{
        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    //int pageSize = 5;
        //    int pageNumber = (page ?? 1);

        //    var tuple = new Tuple<string, int>(searchString, (page ?? 1));
        //    return tuple;

        //}
    }
}