using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehiclesProject.Common
{
    public class Filtering : IFiltering
    {
        #region Properties

        /// <summary>
        /// Gets and sets the search input.
        /// </summary>
        public string SearchString { get; set;}

        #endregion Properties

        #region Constructors

        public Filtering(string currentFilter, string searchString)
        {
            if (searchString == null)
            {
                this.SearchString = currentFilter;
            }
            else
                this.SearchString = searchString;
        }

        #endregion Constructors

    }
}