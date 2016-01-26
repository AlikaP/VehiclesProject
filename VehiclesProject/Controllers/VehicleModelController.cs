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

namespace VehiclesProject.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleContext context = new VehicleContext();

        private IVehicleModelRepository modelRepository;

        public VehicleModelController()
        {
            this.modelRepository = new VehicleModelRepository(new VehicleContext());
        }

        //potencijalno testiranje
        public VehicleModelController(IVehicleModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }


        // GET: VehicleModels/Details/id
        public ActionResult Details(int? id)
        {      
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var vehicleModel = modelRepository.GetSingle(id, "Make");

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
            return View(new VehicleModel());
        }

        // POST: VehicleModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleModel model, int? id)
        {       
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {                
                modelRepository.Create(model, id);

                return RedirectToAction("Details", "VehicleMake", new { id });
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }
        }

        // GET: VehicleModels/Edit/id
        [HttpGet]
        public ActionResult Edit(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var make = modelRepository.GetSingle(id, null);

            if (make == null)
            {
                return HttpNotFound();
            }

            return View(make);
        }

        // POST: VehicleModels/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleModel model)
        {           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {                
                modelRepository.Edit(id, model);
                
                var vehicleModel = modelRepository.GetSingle(id, null);     

                return RedirectToAction("Details", "VehicleMake", new { id = vehicleModel.MakeId });
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes, please try again");
                return View(model);
            }


        }

        // GET: VehicleModels/Delete/id
        [HttpGet]
        public ActionResult Delete(int? id, int? makeId)
        {            
            if (id == null || makeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var make = modelRepository.GetSingle(id, null);

            if (make == null)
            {
                return HttpNotFound();
            }

            return View(make);
        }

        // POST: VehicleModels/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int makeId)
        {            
            try
            {                
                modelRepository.Delete(id);
                                
                return RedirectToAction("Details", "VehicleMake", new { id = makeId });
            }
            catch (DataException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

    }
}
