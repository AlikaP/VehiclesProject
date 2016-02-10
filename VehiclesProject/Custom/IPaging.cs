using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Data;

namespace VehiclesProject.Custom
{
    public interface IPaging
    {
        //Tuple<string, int> SetPagination(string currentFilter, string searchString, int? page);

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
