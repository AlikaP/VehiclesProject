using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesProject.Data;
using VehiclesProject.Models;

namespace VehiclesProject.Custom
{
    public interface ISorting
    {
        //IOrderedEnumerable<T> SortingBy<T>(IQueryable<T> filteredModel, string sortingSwitch, Func<T, string> order) where T : class;
        // Func<T, string> GetSortingBy<T>(string sortingSwitch) where T : class, IVehicle;

        #region Properties

        /// <summary>
        /// Gets the sort pairs.
        /// </summary>
        IList<ISortingPair> Sorters { get; }

        #endregion Properties

    }
}
