using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehiclesProject.Controllers
{
    public class HomeController : Controller
    {
        #region Methods

        /// <summary>
        /// Gets the main page.
        /// </summary>
        /// <returns> Main page. </returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the 'About' page.
        /// </summary>
        /// <returns> The 'About' page. </returns>
        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        /// <summary>
        /// Gets the 'Contact' page.
        /// </summary>
        /// <returns> The 'Contact' page. </returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        #endregion Methods
    }
}