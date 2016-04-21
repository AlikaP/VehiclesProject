using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehiclesProject.Model;
using System.Net.Http;
using PagedList;
using VehiclesProject.Repository;
using VehiclesProject.Common;
using VehiclesProject.Repository.Common;
using VehiclesProject.Model.Common;
using VehiclesProject.Service;
using VehiclesProject.Service.Common;
using AutoMapper;

namespace VehiclesProject.Controllers
{
    public class VehicleMakeController : Controller
    {
        #region Fields

        IVehicleMakeService vehicleMakeService = new VehicleMakeService();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Gets filtred, paged list of all vehicle makes, sorted by "Name".
        /// Every single make from the list is editable, can be deleted and user can check it for details.
        /// </summary>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortOrder"></param>
        /// <param name="orderBy"></param>
        /// <returns> The vehicle makes list. </returns>
        public ActionResult Index(string currentFilter, string searchString, int? pageNumber, int? pageSize, bool? sortOrder, string orderBy="Name")
        {
            try
            {
                // Sets the order of list's elements by parameters.
                ViewBag.CurrentSortOrder = sortOrder;
                ViewBag.CurrentSortParam = orderBy;

                if (sortOrder == true)
                    ViewBag.SortOrder = false;
                else if (sortOrder == false)
                    ViewBag.SortOrder = true;
                else if (sortOrder == null)
                {
                    ViewBag.SortOrder = false;
                    sortOrder = true;
                }

                // Gets the number of makes.
                ViewBag.NumItems = vehicleMakeService.GetItemNum();

                // Setting the current filter.
                if (searchString != null)
                    ViewBag.CurrentFilter = searchString;
                else
                    ViewBag.CurrentFilter = currentFilter;

                // Gets the paged list by creating filtering/paging/sorting objects.
                var model = vehicleMakeService.GetMakes(new Filtering(currentFilter, searchString),
                                                            new Paging(pageNumber, pageSize),
                                                            new Sorting(new SortingPair(sortOrder, orderBy)));

                return View(model);

            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        /// <summary>
        /// Gets the details of a single vehicle makes, including "Name", "Abbrevation" and the list of it's models.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="searchString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns> The details of a single vehicle make. </returns>
        public ActionResult Details(Guid id, string searchString, int? pageNumber, int? pageSize)
        {          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                // Gets the single make by id.
                var vehicleMake = vehicleMakeService.GetSingleMake(id, "VehicleModels");

                if (vehicleMake == null)
                {
                    return HttpNotFound();
                }

                return View(vehicleMake);

            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(500);
            }          
        }

        /// <summary>
        /// Gets the form for creating new vehicle make.
        /// </summary>
        /// <returns> Form for creating new vehicle make. </returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new VehicleMakePoco());
        }

        /// <summary>
        /// Saves new vehicle make.
        /// </summary>
        /// <param name="model"></param>
        /// <returns> List of makes. </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleMakePoco model)
        {           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Calls the method for creating new make;
                vehicleMakeService.Create(model);

                return RedirectToAction("index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }
        }

        /// <summary>
        /// Gets the form for updating existing vehicle make.
        /// </summary>
        /// <returns> Form for updating existing vehicle make. </returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                // Gets a single vehicle make by id.
                var make = vehicleMakeService.GetSingleMake(id, null);

                if (make == null)
                {
                    return HttpNotFound();
                }

                return View(make);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        /// <summary>
        /// Saves the updated vehicle make.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns> List of makes. </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, VehicleMakePoco model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // Calls a method for updating an existing make.
                vehicleMakeService.Update(id, model);

                return RedirectToAction("index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }
        }

        /// <summary>
        /// Gets the form for deleting a vehicle make by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Confirmation form for deleting a vehicle make. </returns>
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var make = vehicleMakeService.GetSingleMake(id, null);

                if (make == null)
                {
                    return HttpNotFound();
                }

                return View(make);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        /// <summary>
        /// Saves the changes after deleting a single make.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> List of makes. </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                // Calls a method for deleting the specified make.
                vehicleMakeService.Delete(id);

                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        #endregion Methods   
    }
}
