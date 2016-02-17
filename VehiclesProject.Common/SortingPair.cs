using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehiclesProject.Common
{
    public class SortingPair : ISortingPair
    {
        
        public bool? Ascending { get; set; }
        
        public string OrderBy { get; set; }
        
        public SortingPair(bool? ascending, string orderBy)
        {
            this.Ascending = ascending;
            this.OrderBy = orderBy;
        }

        
        public string GetSortExpression()
        {
            string sortExpression = null;

            if (this.Ascending == true)
            {
                sortExpression = this.OrderBy;
            }
            else if(this.Ascending == false)
                sortExpression = this.OrderBy + " descending";

            return sortExpression;
        }
        
    }
}