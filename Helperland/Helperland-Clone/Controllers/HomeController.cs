
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Helperland_Clone.Models;
using Helperland_Clone.ViewModels;
using Helperland_Clone.Services;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contact_Us _contactus;

        
        public HomeController(ILogger<HomeController> logger, Contact_Us _contactus)
        {
            _logger = logger;
            this._contactus = _contactus;
        }

        public IActionResult Index()
        {
            var popupstatus = TempData["SuccessPopUpStatus"];
            var invalidcreds = TempData["InvalidCreds"];
            var errormsg = TempData["Error"];
            if (popupstatus != null)
            {
                ViewBag.PopUpStatus = popupstatus;
                TempData["SuccessPopUpStatus"] = null;
            }
            if (invalidcreds != null)
            {
                ViewBag.InvalidCreds = invalidcreds;
                TempData["InvalidCreds"] = null;
            }
            if (errormsg != null)
            {
                ViewBag.Error = errormsg;
                TempData["Error"] = null;
            }
            return View();
        }

        public IActionResult Prices()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contactus(ContactUsViewModel contact)
        {
            //if (ModelState.IsValid)
            //{
                _contactus.Add(contact);
                //return RedirectToAction("Contact");
            //}
            return RedirectToAction("Contact");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
