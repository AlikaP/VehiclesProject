using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehiclesProject.Data;

namespace VehiclesProject.Custom
{
    public class Sorting : ISorting
    {
        public IOrderedEnumerable<T> SortingBy<T>(IQueryable<T> filteredModel, string sortingSwitch, Func<T, string> order) where T : class
        {
            IOrderedEnumerable<T> sortedModel = null;

            switch (sortingSwitch)
            {
                case "asc":
                    sortedModel = filteredModel.OrderBy(order);
                    break;
                case "desc":
                    sortedModel = filteredModel.OrderByDescending(order);
                    break;
            }

            return sortedModel;
        }
    }
}