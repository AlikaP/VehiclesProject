using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehiclesProject.Common
{
    public class Paging : IPaging
    {
        public int PageNumber { get; }
        
        public int PageSize { get; }

        public Paging(int? pageNumber, int? pageSize)
        {
            this.PageNumber = (pageNumber ?? 1);
            this.PageSize = (pageSize ?? 5);
        }

        //public int GetPage(int? page)
        //{
        //    return (page ?? 1);
        //}
        
    }
}