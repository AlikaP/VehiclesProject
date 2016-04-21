using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Common
{
    public interface IPaging
    {
        #region Properties

        /// <summary>
        /// Gets the Page number.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Gets the Page size.
        /// </summary>
        int PageSize { get; }

        #endregion Properties

    }
}
