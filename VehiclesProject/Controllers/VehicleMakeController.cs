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
        private VehicleContext context = new VehicleContext();

        private IVehicleMakeRepository makeRepository;

        public VehicleMakeController()
        {
            this.makeRepository = new VehicleMakeRepository(new VehicleContext());
        }

        //potencijalno testiranje
        public VehicleMakeController(IVehicleMakeRepository makeRepository)
        {
            this.makeRepository = makeRepository;
        }


        // GET: VehicleMakes
        public  ActionResult Index(string currentFilter, string searchString, int? page)
        {           
            try
            {
                //count
                ViewBag.NumItems = context.VehicleMakes.Count();

                //search
                var vehicleMakes = from m in context.VehicleMakes select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    vehicleMakes = vehicleMakes.Where(m => m.Name == searchString
                                           || m.Abrev == searchString
                                           || m.VehicleModels.Count(s => s.Name == searchString) > 0);
                }

                //paging
                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                int pageSize = 5;
                int pageNumber = (page ?? 1);

                var make = makeRepository.GetPagedList(vehicleMakes, pageNumber, pageSize);
                
                return View(make);
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
                var vehicleMake = makeRepository.GetSingle(id, "VehicleModels");
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
                makeRepository.Create(model);

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

            var make = makeRepository.GetSingle(id, null);

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
                               
                makeRepository.Edit(id, model);

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

            var make = makeRepository.GetSingle(id, null);

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
                makeRepository.Delete(id);

                return RedirectToAction("index");
            }
            catch (DataException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        
    }
}
