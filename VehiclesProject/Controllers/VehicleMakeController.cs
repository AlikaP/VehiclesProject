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

namespace VehiclesProject.Controllers
{
    public class VehicleMakeController : Controller
    {
        //UnitOfWork unitOfWork = new UnitOfWork();

        IVehicleMakeRepository vehicleMakeRepository = new VehicleMakeRepository();

        // GET: VehicleMakes
        public  ActionResult Index(string currentFilter, string searchString, int? pageNumber, int? pageSize, bool? sortOrder, string orderBy="Name")
        {

            

                //sort
                ViewBag.CurrentSortOrder = sortOrder;
                ViewBag.CurrentSortParam = orderBy;

                if (sortOrder == true)
                    ViewBag.SortOrder = false;
                else if (sortOrder == false)
                    ViewBag.SortOrder = true;
                else if (sortOrder == null)
                    { ViewBag.SortOrder = false; sortOrder = true; }

                ViewBag.NumItems = vehicleMakeRepository.GetItemNum();
            

                //search
                if (searchString != null)
                        ViewBag.CurrentFilter = searchString;
                    else
                        ViewBag.CurrentFilter = currentFilter;

                    var model = vehicleMakeRepository.GetMakes(new Filtering(currentFilter, searchString),
                                                                new Paging(pageNumber, pageSize),
                                                                new Sorting(new SortingPair(sortOrder, orderBy)));

             
                return View(model);

            

        }

        // GET: VehicleMakes/Details/id
        public ActionResult Details(int? id, string searchString)
        {                        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {

                var vehicleMake = vehicleMakeRepository.GetSingleMake(id, "VehicleModels", new Filtering(null, searchString));
                ViewBag.NumItems = vehicleMakeRepository.GetModelNum(id);
                //ViewBag.NumItems = vehicleMake.VehicleModels.Count();

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
                vehicleMakeRepository.Create(model);

                return RedirectToAction("index");
            }
            catch (DataException)
            {                
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }
        }

        // GET: VehicleMakes/Edit/id
        [HttpGet]
        public ActionResult Edit(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var make = vehicleMakeRepository.GetSingleMake(id, null, null);

            if (make == null)
            {
                return HttpNotFound();
            }

            return View(make);
        }

        // POST: VehicleMakes/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, VehicleMakePoco model)
        {            
            if (!ModelState.IsValid)
            {
                return View(model);
            }       

            try
            {
                               
                vehicleMakeRepository.Edit(id, model);

                return RedirectToAction("index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }


        }

        // GET: VehicleMakes/Delete/id
        [HttpGet]
        public ActionResult Delete(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var make = vehicleMakeRepository.GetSingleMake(id, null, null);

            if (make == null)
            {
                return HttpNotFound();
            }
            
            return View(make);
        }

        // POST: VehicleMakes/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {            
            try
            {                
                vehicleMakeRepository.Delete(id);

                return RedirectToAction("index");
            }
            catch (DataException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        
    }
}
