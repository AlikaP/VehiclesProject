using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehiclesProject.Common
{
    public class Paging : IPaging
    {
        #region Properties

        /// <summary>
        /// Gets the Page number.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// Gets the Page size.
        /// </summary>
        public int PageSize { get; }

        #endregion Properties

        #region Constructors

        public Paging(int? pageNumber, int? pageSize)
        {
            this.PageNumber = (pageNumber ?? 1);
            this.PageSize = (pageSize ?? 5);
        }

        #endregion Constructors


    }
}