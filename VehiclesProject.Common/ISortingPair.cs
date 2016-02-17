using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Common
{
    public interface ISortingPair
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating if order direction is ascending.
        /// </summary>
        bool? Ascending { get; set; }

        /// <summary>
        /// Gets or sets the order by field.
        /// </summary>
        string OrderBy { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the sort expression.
        /// </summary>
        /// <returns>Sort expression.</returns>
        string GetSortExpression();

        #endregion Methods
    }
}
