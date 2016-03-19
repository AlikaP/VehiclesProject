using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehiclesProject.Common
{
    public class Sorting : ISorting
    {              
        public IList<ISortingPair> Sorters { get; }
        
        public Sorting(ISortingPair sortOrder)
        {
            Sorters = new List<ISortingPair>();
            Sorters.Add(sortOrder);
        }
        
        //public Func<T, string> GetSortingBy<T>(string sortingSwitch) where T : class
        //{
        //    Func<T, string> sort = null;

        //    switch (sortingSwitch)
        //    {
        //        case "name":
        //            sort = m=>m.Name;
        //            break;
        //        case "abrev":
        //            sort = m=>m.Abrev;
        //            break;
        //    }

        //    return sort;
        //}

        //public IOrderedEnumerable<T> SortingBy<T>(IQueryable<T> filteredModel, string sortingSwitch, Func<T, string> order) where T : class
        //{
        //    IOrderedEnumerable<T> sortedModel = null;

        //    switch (sortingSwitch)
        //    {
        //        case "asc":
        //            sortedModel = filteredModel.OrderBy(order);
        //            break;
        //        case "desc":
        //            sortedModel = filteredModel.OrderByDescending(order);
        //            break;
        //    }

        //    return sortedModel;
        //}
    }
}