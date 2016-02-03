using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehiclesProject.Data;
using VehiclesProject.Models;
using System.Net.Http;

using PagedList;

namespace VehiclesProject.Controllers
{
    public class VehicleMakeController : Controller
    {
        //UnitOfWork unitOfWork = new UnitOfWork();

        IVehicleMakeRepository vehicleMakeRepository = new VehicleMakeRepository();

        // GET: VehicleMakes
        public  ActionResult Index(string currentFilter, string searchString, int? page)
        {           
            try
            {
               
                ViewBag.NumItems = vehicleMakeRepository.GetItemNum();
                
                ViewBag.CurrentFilter = searchString;

               
                var model = vehicleMakeRepository.GetMakes(currentFilter, searchString, page);
               
                
                return View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        // GET: VehicleMakes/Details/id
        public ActionResult Details(int? id)
        {                        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var vehicleMake = vehicleMakeRepository.GetSingleMake(id, "VehicleModels");
                ViewBag.NumItems = vehicleMake.VehicleModels.Count();

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
            return View(new VehicleMake());
        }

        // POST: VehicleMakes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleMake model)
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

            var make = vehicleMakeRepository.GetSingleMake(id, null);

            if (make == null)
            {
                return HttpNotFound();
            }

            return View(make);
        }

        // POST: VehicleMakes/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, VehicleMake model)
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

            var make = vehicleMakeRepository.GetSingleMake(id, null);

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
