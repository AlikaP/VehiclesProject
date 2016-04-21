using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehiclesProject.Common;
using VehiclesProject.Model;
using VehiclesProject.Repository;
using VehiclesProject.Repository.Common;
using VehiclesProject.Service;
using VehiclesProject.Service.Common;

namespace VehiclesProject.Controllers
{
    public class VehicleModelController : Controller
    {
        #region Fields

        IVehicleModelService vehicleModelService = new VehicleModelService();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Gets filtred, paged list of the correspongind vehicle models, sorted by "Name".
        /// Every single model from the list is editable, can be deleted and user can check it for details.
        /// </summary>
        /// <param name="makeId"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortOrder"></param>
        /// <param name="orderBy"></param>
        /// <returns> The partial view for vehicle models list. </returns>
        [HttpGet]
        public PartialViewResult _VehicleModelList(Guid makeId, string currentFilter, string searchString, int? pageNumber, int? pageSize, bool? sortOrder, string orderBy = "Name")
        {
            try
            {
                // Sets the order of list elements by parameters.
                ViewBag.makeId = makeId;

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

                // Gets the number of models of the specific make (by foreign key makeId).
                ViewBag.NumItems = vehicleModelService.GetModelNum(makeId);

                // Setting the current filter.
                if (searchString != null)
                    ViewBag.CurrentFilter = searchString;
                else
                    ViewBag.CurrentFilter = currentFilter;

                // Gets the paged list by creating filtering/paging/sorting objects.
                var model = vehicleModelService.GetModels(makeId, new Filtering(currentFilter, searchString),
                                                            new Paging(pageNumber, pageSize),
                                                            new Sorting(new SortingPair(sortOrder, orderBy)));

                return PartialView(model);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to load model list, please try again");
                return PartialView("Error");
            }

        }

        /// <summary>
        /// Gets the details of a single vehicle model.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> The details of a single vehicle model. </returns>
        public ActionResult Details(Guid id)
        {      
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            { 
                // Loads models of the specified make, including their navigation properties
                var vehicleModel = vehicleModelService.GetSingleModel(id, "Make");

                if (vehicleModel == null)
                {
                    return HttpNotFound();
                }

                return View(vehicleModel);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        /// <summary>
        /// Gets the form for creating new vehicle model.
        /// </summary>
        /// <returns> Form for creating new vehicle model. </returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new VehicleModelPoco());
        }

        /// <summary>
        /// Saves new vehicle model.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns> 'Details' page for a vehicle make. </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleModelPoco model, Guid id)
        {       
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Creates new model of a specific make.
                vehicleModelService.Create(model, id);

                return RedirectToAction("Details", "VehicleMake", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save, please try again");
                return View(model);
            }
        }

        /// <summary>
        /// Gets the form for updating existing vehicle model.
        /// </summary>
        /// <returns> Form for updating existing vehicle model. </returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {                        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                // Gets a single model by id. 
                var make = vehicleModelService.GetSingleModel(id, null);

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
        /// Saves the updated vehicle model.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns> 'Details' page for a vehicle make. </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, VehicleModelPoco model)
        {           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Updates existing model.
                vehicleModelService.Update(id, model);
 
                var vehicleModel = vehicleModelService.GetSingleModel(id, null);

                return RedirectToAction("Details", "VehicleMake", new { id = vehicleModel.MakeId });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }
        }


        /// <summary>
        /// Gets the form for deleting a vehicle model by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="makeId"></param>
        /// <returns> Confirmation form for deleting a vehicle model. </returns>
        [HttpGet]
        public ActionResult Delete(Guid id, Guid makeId)
        {            
            if (id == null || makeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                // Gets single model by id.
                var make = vehicleModelService.GetSingleModel(id, null);

                if (make == null)
                {
                    return HttpNotFound();
                }

                return View(make);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Saves the changes after deleting a single model.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="makeId"></param>
        /// <returns> 'Details' page for a vehicle make.  </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id, Guid makeId)
        {
            try
            {
                // Deletes the model specified by id.
                vehicleModelService.Delete(id);

                return RedirectToAction("Details", "VehicleMake", new { id = makeId });
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        #endregion Methods
    }
}
