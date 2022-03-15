using Microsoft.AspNetCore.Mvc;
using Helperland_Clone.Data;
using Helperland_Clone.Models;
using System.Linq;
using Helperland_Clone.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using Helperland_Clone.Services;
using Helperland_Clone.Enums;

namespace Helperland_Clone.Controllers
{
    public class BookServiceController : Controller
    {
        private readonly HelperlandContext _db;
        private readonly IUserService _userService;
        private User loggedUser;

        public BookServiceController(HelperlandContext db, IUserService userService)
        {
            this._db = db;
            _userService = userService;
        }
        public IActionResult ServiceBooking()
        {
            //ViewBag.activetab = "tab-1";
            return View();
        }

        [HttpPost]
        public IActionResult CheckPostalCode(ServiceBookingCombinedViewModel model)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var availSP = _db.User.Where(z => (z.ZipCode == model.postalCode.zipCode) && (z.UserTypeId == 2)).ToList();

                if (availSP.Count() > 0)
                {
                    return Ok(Json("true"));
                }
                return Ok(Json("false"));
            }
            else
            {
                return Ok(Json("Invalid"));
            }
        }

        [HttpPost]
        public ActionResult ScheduleService(ServiceBookingCombinedViewModel model)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            User user = _db.User.Where(x => x.UserId == Id).FirstOrDefault();

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    return Ok(Json("true"));
                }

                return Ok(Json("ClicklogInBtn"));
            }
            else
            {
                return Ok(Json("false"));
            }
        }

        [HttpGet]
        public IActionResult CustomerDetails(ServiceBookingCombinedViewModel model)
        {
            //int Id = -1;

            List<AddressViewModel> Addresses = new List<AddressViewModel>();

            //var logedin = HttpContext.Session.GetInt32("userId");
            //if (HttpContext.Session.GetInt32("userId") != null)
            //{
            //    //Id = (int)HttpContext.Session.GetInt32("userId");
                
            //}
            //else if (Request.Cookies["userId"] != null)
            //{
            //    //Id = int.Parse(Request.Cookies["userId"]);
            //}

            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            string postalcode = model.postalCode.zipCode;
            Console.WriteLine(model.postalCode.zipCode);
            var table = _db.UserAddress.Where(x => x.UserId == Id && x.PostalCode == postalcode).ToList();
            Console.WriteLine(table.ToString());

            foreach (var add in table)
            {
                Console.WriteLine("1");
                AddressViewModel useradd = new AddressViewModel();
                useradd.AddressId = add.AddressId;
                useradd.AddressLine1 = add.AddressLine1;
                useradd.AddressLine2 = add.AddressLine2;
                useradd.City = add.City;
                useradd.PostalCode = add.PostalCode;
                useradd.Mobile = add.Mobile;
                useradd.isDefault = add.IsDefault;

                Addresses.Add(useradd);
            }
            Console.WriteLine("2");

            return new JsonResult(Addresses);
        }

        [HttpPost]
        public ActionResult AddNewAddress(UserAddress useradd)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Inside Addnew address 1");
                //int Id = -1;


                //if (HttpContext.Session.GetInt32("userId") != null)
                //{
                //    Id = (int)HttpContext.Session.GetInt32("userId");
                //}
                //else if (Request.Cookies["userId"] != null)
                //{
                //    Id = int.Parse(Request.Cookies["userId"]);

                //}
                var userId = _userService.GetUserId();
                int Id = Convert.ToInt32(userId);

                Console.WriteLine("Inside Addnew address 2");
                Console.WriteLine(Id);

                useradd.UserId = Id;
                useradd.IsDefault = false;
                useradd.IsDeleted = false;
                User user = _db.User.Where(x => x.UserId == Id).FirstOrDefault();
                useradd.Email = user.Email;
                var result = _db.UserAddress.Add(useradd);
                Console.WriteLine("Inside Addnew address 3");
                _db.SaveChanges();

                Console.WriteLine("Inside Addnew address 4");
                if (result != null)
                {
                    return Ok(Json("true"));
                }

                return Ok(Json("false"));
            }
            return View();
        }


        public ActionResult GenerateServiceRequest(ServiceRequestViewModel complete)
        {
            //int Id = -1;


            //if (HttpContext.Session.GetInt32("userId") != null)
            //{
            //    Id = (int)HttpContext.Session.GetInt32("userId");
            //}
            //else if (Request.Cookies["userId"] != null)
            //{
            //    Id = int.Parse(Request.Cookies["userId"]);

            //}
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);


            ServiceRequest add = new ServiceRequest();
            add.UserId = Id;
            add.ServiceStartDate = complete.ServiceStartDate;
            add.ServiceHours = (double)complete.ServiceHours;
            add.ZipCode = complete.PostalCode;
            add.ServiceHourlyRate = 25;
            add.ExtraHours = complete.ExtraHours;
            add.SubTotal = (decimal)complete.SubTotal;
            add.TotalCost = (decimal)complete.TotalCost;
            add.Comments = complete.Comments;
            add.PaymentDue = false;
            add.PaymentDone = true;
            add.HasPets = complete.HasPets;
            add.Status = (int)ServiceRequestStatusEnum.Open;
            add.ModifiedBy = Id;
            add.CreatedDate = DateTime.Now;
            add.ModifiedDate = DateTime.Now;
            add.HasIssue = false;

            int newServiceId = 999;
            try
            {
                newServiceId = _db.ServiceRequest.Max(x => x.ServiceId);
            }
            catch (Exception)
            {
                newServiceId = 999;
            }

            newServiceId++;
            add.ServiceId = newServiceId;

            var result = _db.ServiceRequest.Add(add);
            _db.SaveChanges();

            UserAddress useraddr = _db.UserAddress.Where(x => x.AddressId == complete.AddressId).FirstOrDefault();

            ServiceRequestAddress srAddr = new ServiceRequestAddress();
            srAddr.AddressLine1 = useraddr.AddressLine1;
            srAddr.AddressLine2 = useraddr.AddressLine2;
            srAddr.City = useraddr.City;
            srAddr.Email = useraddr.Email;
            srAddr.Mobile = useraddr.Mobile;
            srAddr.PostalCode = useraddr.PostalCode;
            srAddr.ServiceRequestId = result.Entity.ServiceRequestId;
            srAddr.State = useraddr.State;

            var srAddrResult = _db.ServiceRequestAddress.Add(srAddr);
            _db.SaveChanges();

            if (complete.Cabinet == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra();
                srExtra.ServiceRequestId = result.Entity.ServiceRequestId;
                srExtra.ServiceExtraId = 1;
                _db.ServiceRequestExtra.Add(srExtra);
                _db.SaveChanges();
            }
            if (complete.Fridge == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra();
                srExtra.ServiceRequestId = result.Entity.ServiceRequestId;
                srExtra.ServiceExtraId = 2;
                _db.ServiceRequestExtra.Add(srExtra);
                _db.SaveChanges();
            }
            if (complete.Oven == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra();
                srExtra.ServiceRequestId = result.Entity.ServiceRequestId;
                srExtra.ServiceExtraId = 3;
                _db.ServiceRequestExtra.Add(srExtra);
                _db.SaveChanges();
            }
            if (complete.Laundry == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra();
                srExtra.ServiceRequestId = result.Entity.ServiceRequestId;
                srExtra.ServiceExtraId = 4;
                _db.ServiceRequestExtra.Add(srExtra);
                _db.SaveChanges();
            }
            if (complete.Window == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra();
                srExtra.ServiceRequestId = result.Entity.ServiceRequestId;
                srExtra.ServiceExtraId = 5;
                _db.ServiceRequestExtra.Add(srExtra);
                _db.SaveChanges();
            }



            if (result != null && srAddrResult != null)
            {
                return Ok(Json(result.Entity.ServiceRequestId));
            }

            return Ok(Json("false"));
        }




    }
}
