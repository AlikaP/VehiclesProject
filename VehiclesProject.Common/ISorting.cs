using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Common
{
    public interface ISorting
    {
        #region Properties

        /// <summary>
        /// Gets a list of sorting pairs.
        /// </summary>
        IList<ISortingPair> Sorters { get; }

        #endregion Properties

    }
}
