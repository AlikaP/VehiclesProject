using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject.Common
{
    public interface IFiltering
    {
        #region Properties

        /// <summary>
        /// Gets and sets the search input.
        /// </summary>
        string SearchString { get; set; }

        #endregion Properties
    }
}
