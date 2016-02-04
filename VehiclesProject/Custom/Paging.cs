using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehiclesProject.Data;

namespace VehiclesProject.Custom
{
    public class Paging : IPaging
    {
        
        public int GetPage(int? page)
        {
            return (page ?? 1);
        }

        
    }
}