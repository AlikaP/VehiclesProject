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

namespace VehiclesProject.Controllers
{
    public class VehicleMakeController : Controller
    {
        //UnitOfWork unitOfWork = new UnitOfWork();

        IVehicleMakeService vehicleMakeService = new VehicleMakeService();

        // GET: VehicleMakes
        public ActionResult Index(string currentFilter, string searchString, int? pageNumber, int? pageSize, bool? sortOrder, string orderBy="Name")
        {
            try
            {
                // Sorting.
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

                ViewBag.NumItems = vehicleMakeService.GetItemNum();

                // Search.
                if (searchString != null)
                    ViewBag.CurrentFilter = searchString;
                else
                    ViewBag.CurrentFilter = currentFilter;

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

        // GET: VehicleMakes/Details/id
        public ActionResult Details(Guid id, string searchString, int? pageNumber, int? pageSize)
        {          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var vehicleMake = vehicleMakeService.GetSingleMake(id, "VehicleModels");
                //ViewBag.NumItems = vehicleMakeService.GetModelNum(id);
                ////ViewBag.NumItems = vehicleMake.VehicleModels.Count();

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

        // GET: VehicleMakes/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new VehicleMakePoco());
        }

        // POST: VehicleMakes/Create
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
                vehicleMakeService.Create(model);

                return RedirectToAction("index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }
        }

        // GET: VehicleMakes/Edit/id
        [HttpGet]
        public ActionResult Edit(Guid id)
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

        // POST: VehicleMakes/Edit/id
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

                vehicleMakeService.Update(id, model);

                return RedirectToAction("index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }
        }

        // GET: VehicleMakes/Delete/id
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

        // POST: VehicleMakes/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                vehicleMakeService.Delete(id);

                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }       
    }
}
