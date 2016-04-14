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
        IVehicleModelService vehicleModelService = new VehicleModelService();

        //private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpGet]
        public PartialViewResult _VehicleModelList(Guid makeId, string currentFilter, string searchString, int? pageNumber, int? pageSize, bool? sortOrder, string orderBy = "Name")
        {
            try
            {
                //sort

                // 
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

            ViewBag.NumItems = vehicleModelService.GetModelNum(makeId);

            //search
            if (searchString != null)
                ViewBag.CurrentFilter = searchString;
            else
                ViewBag.CurrentFilter = currentFilter;

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

        // GET: VehicleModels/Details/id
        public ActionResult Details(Guid id)
        {      
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            { 
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

        // GET: VehicleModels/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new VehicleModelPoco());
        }

        // POST: VehicleModels/Create
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
                vehicleModelService.Create(model, id);

                return RedirectToAction("Details", "VehicleMake", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save, please try again");
                return View(model);
            }
        }

        // GET: VehicleModels/Edit/id
        [HttpGet]
        public ActionResult Edit(Guid id)
        {                        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
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

        // POST: VehicleModels/Edit/id
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

        // GET: VehicleModels/Delete/id
        [HttpGet]
        public ActionResult Delete(Guid id, Guid makeId)
        {            
            if (id == null || makeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
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

        // POST: VehicleModels/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id, Guid makeId)
        {
            try
            {
                vehicleModelService.Delete(id);

                return RedirectToAction("Details", "VehicleMake", new { id = makeId });
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}
