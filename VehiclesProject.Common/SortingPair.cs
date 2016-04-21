using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehiclesProject.Common
{
    public class SortingPair : ISortingPair
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating if order direction is ascending.
        /// </summary>
        public bool? Ascending { get; set; }

        /// <summary>
        /// Gets or sets the order by field.
        /// </summary>
        public string OrderBy { get; set; }

        #endregion Properties

        #region Constructors

        public SortingPair(bool? ascending, string orderBy)
        {
            this.Ascending = ascending;
            this.OrderBy = orderBy;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the sort expression.
        /// </summary>
        /// <returns>Sort expression.</returns>      
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

        #endregion Methods

    }
}