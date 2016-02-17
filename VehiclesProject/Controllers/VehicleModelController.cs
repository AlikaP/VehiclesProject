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

namespace VehiclesProject.Controllers
{
    public class VehicleModelController : Controller
    {
        IVehicleModelRepository vehicleModelRepository = new VehicleModelRepository();

        //private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: VehicleModels/Details/id
        public ActionResult Details(int? id)
        {      
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var vehicleModel = vehicleModelRepository.GetSingleModel(id, "Make");

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
        public ActionResult Create(VehicleModelPoco model, int? id)
        {       
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                vehicleModelRepository.Create(model, id);

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

            var make = vehicleModelRepository.GetSingleModel(id, null);

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

            
                vehicleModelRepository.Edit(id, model);
                
                var vehicleModel = vehicleModelRepository.GetSingleModel(id, null);     

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

            var make = vehicleModelRepository.GetSingleModel(id, null);

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
                vehicleModelRepository.Delete(id);
                                
                return RedirectToAction("Details", "VehicleMake", new { id = makeId });
            }
            catch (DataException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

       

    }
}
