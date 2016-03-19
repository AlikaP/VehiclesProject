using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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

        // GET: VehicleModels/Details/id
        public ActionResult Details(int? id)
        {      
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vehicleModel = vehicleModelService.GetSingleModel(id, "Make");

            if (vehicleModel == null)
            {
                return HttpNotFound();
            }

            return View(vehicleModel);
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
        public ActionResult Create(VehicleModelPoco model, int? id)
        {       
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            vehicleModelService.Create(model, id);

            return RedirectToAction("Details", "VehicleMake", new { id });
        }

        // GET: VehicleModels/Edit/id
        [HttpGet]
        public ActionResult Edit(int? id)
        {                        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var make = vehicleModelService.GetSingleModel(id, null);

            if (make == null)
            {
                return HttpNotFound();
            }

            return View(make);
        }

        // POST: VehicleModels/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleModelPoco model)
        {           
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            vehicleModelService.Edit(id, model);
                
            var vehicleModel = vehicleModelService.GetSingleModel(id, null);     

            return RedirectToAction("Details", "VehicleMake", new { id = vehicleModel.MakeId });
        }

        // GET: VehicleModels/Delete/id
        [HttpGet]
        public ActionResult Delete(int? id, int? makeId)
        {            
            if (id == null || makeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var make = vehicleModelService.GetSingleModel(id, null);

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
            vehicleModelService.Delete(id);
                                
            return RedirectToAction("Details", "VehicleMake", new { id = makeId });         
        }
    }
}
