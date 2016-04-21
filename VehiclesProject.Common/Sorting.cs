using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehiclesProject.Common
{
    public class Sorting : ISorting
    {
        #region Properties

        /// <summary>
        /// Gets a list of sorting pairs.
        /// </summary>
        public IList<ISortingPair> Sorters { get; }

        #endregion Properties

        #region Constructors

        public Sorting(ISortingPair sortOrder)
        {
            Sorters = new List<ISortingPair>();
            Sorters.Add(sortOrder);
        }

        #endregion Constructors

    }
}