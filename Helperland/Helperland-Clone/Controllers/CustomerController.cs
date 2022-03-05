using Microsoft.AspNetCore.Mvc;
using Helperland_Clone.Services;
using Helperland_Clone.Data;
using System.Collections.Generic;
using Helperland_Clone.Models;
using Helperland_Clone.ViewModels;
using System;
using System.Linq;
using Helperland_Clone.Enums;

namespace Helperland_Clone.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HelperlandContext _db;
        private readonly IUserService _userService;

        public CustomerController(HelperlandContext db, IUserService userService)
        {
            this._db = db;
            _userService = userService;
        }

        public IActionResult CustomerDashboard()
        {
            CombinedAllViewModels combine = new CombinedAllViewModels();
            List<CustomerDashboardViewModel> dashboard = new List<CustomerDashboardViewModel>();
            List<AddressViewModel> addresses = new List<AddressViewModel>();

            var userId = _userService.GetUserId();
            var userTypeId = _userService.GetUserTypeId();

            int Id = Convert.ToInt32(userId);
            int TypeId = Convert.ToInt32(userTypeId);

            string userName = _userService.GetUserName();
            ViewData["UserName"] = userName;

            if (TypeId == 3)
            {
                //var table = _db.ServiceRequest.Where(x => x.UserId == Id).ToList();
                List<ServiceRequest> requests = (from request in this._db.ServiceRequest.Where(x => x.UserId == Id)
                                                 select request).ToList();

                if (requests.Any())  /*request.Count()>0*/
                {
                    foreach (var service in requests)
                    {

                        CustomerDashboardViewModel dash = new CustomerDashboardViewModel();
                        dash.ServiceId = service.ServiceId;
                        var StartDate = service.ServiceStartDate.ToString();
                        dash.Date = service.ServiceStartDate.ToString("dd/MM/yyyy");
                        dash.StartTime = service.ServiceStartDate.AddHours(0).ToString("HH:mm ");
                        var totaltime = (double)(service.ServiceHours + service.ExtraHours);
                        dash.EndTime = service.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");
                        dash.Status = (int)service.Status;
                        dash.TotalCost = service.TotalCost;

                        if (service.ServiceProviderId != null)
                        {

                            User sp = _db.User.Where(x => x.UserId == service.ServiceProviderId).FirstOrDefault();

                            dash.ServiceProvider = sp.FirstName + " " + sp.LastName;

                            //decimal rating = _db.Ratings.Where(x => x.RatingTo == service.ServiceProviderId).Average(x => x.Ratings);

                            //dash.SPRatings = rating;

                        }

                        dashboard.Add(dash);
                    }

                    combine.DashboardViewModel = dashboard;
                }


                List<UserAddress> addList = (from address in this._db.UserAddress.Where(x => x.UserId == Id)
                                             select address).ToList();

                if (addList.Any())  /*request.Count()>0*/
                {
                    foreach (var item in addList)
                    {

                        AddressViewModel addModel = new AddressViewModel();
                        addModel.AddressId = item.AddressId;
                        addModel.AddressLine1 = item.AddressLine1;
                        addModel.AddressLine2 = item.AddressLine2;
                        addModel.PostalCode = item.PostalCode;
                        addModel.City = item.City;
                        addModel.Mobile = item.Mobile;
                        addModel.isDefault = item.IsDefault;


                        addresses.Add(addModel);
                    }

                    combine.DashboardViewModel = dashboard;
                    combine.address = addresses;
                }

                User user = _db.User.Where(_ => _.UserId == Id).FirstOrDefault();
                ViewBag.firstName = user.FirstName;
                ViewBag.lastName = user.LastName;
                ViewBag.email = user.Email;
                ViewBag.mobile = user.Mobile;


                return View(combine);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RescheduleServiceRequest(CustomerDashboardViewModel reschedule)
        {
            ServiceRequest rescheduleService = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == (int)reschedule.ServiceId);

            Console.WriteLine(reschedule.ServiceId);

            string date = reschedule.Date + " " + reschedule.StartTime;
            Console.WriteLine(reschedule.Date);

            rescheduleService.ServiceStartDate = DateTime.Parse(date);
            rescheduleService.ModifiedDate = DateTime.Now;

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
            rescheduleService.ServiceId = newServiceId;

            var result = _db.ServiceRequest.Update(rescheduleService);
            _db.SaveChanges();

            //CustomerDashboardViewModel updatedDetails = new CustomerDashboardViewModel();
            //updatedDetails.Date = rescheduleService.ServiceStartDate.ToString("dd/MM/yyyy");
            //updatedDetails.StartTime = rescheduleService.ServiceStartDate.ToString("HH:mm ");
            //var totaltime = (double)(rescheduleService.ServiceHours + rescheduleService.ExtraHours);
            //updatedDetails.EndTime = rescheduleService.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");


            if (result != null)
            {
                return Ok(Json("true"));
                //return new JsonResult(updatedDetails);
            }

            return Ok(Json("false"));
        }

        [HttpPost]
        public IActionResult CancelServiceRequest(ServiceRequest cancel)
        {
            Console.WriteLine(cancel.ServiceRequestId);
            ServiceRequest cancelService = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == cancel.ServiceId);
            cancelService.Status = (int)ServiceRequestStatusEnum.Cancelled;
            if (cancel.Comments != null)
            {
                cancelService.Comments = cancel.Comments;
            }

            var result = _db.ServiceRequest.Update(cancelService);
            _db.SaveChanges();
            if (result != null)
            {
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }

        [HttpPost]
        public IActionResult ChangeDetails(CombinedAllViewModels model)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            User user = _db.User.Where(_ => _.UserId == Id).FirstOrDefault();
            user.FirstName = model.details.Fname;
            user.LastName = model.details.Lname;
            user.Email = model.details.email;
            user.Mobile = model.details.mobileNumber;

            if (model.details.DayOfBirth != 0 && model.details.MonthOfBirth != 0 && model.details.YearOfBirth != 0)
            {
                string date = model.details.DayOfBirth.ToString() + "/" + model.details.MonthOfBirth.ToString() + "/" + model.details.YearOfBirth.ToString();
                var dateOfBirth = Convert.ToDateTime(date);
                user.DateOfBirth = dateOfBirth;
            }

            var result = _db.User.Update(user);
            _db.SaveChanges();

            if (result != null)
            {
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }

        [HttpPost]
        public IActionResult ChangePassword(CombinedAllViewModels model)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);
            if (ModelState.IsValid)
            {
                User user = _db.User.Where(_ => _.UserId == Id).FirstOrDefault();

                if (user != null)
                {
                    if (user.Password != model.changePsw.OldPassword)
                    {
                        return Ok(Json("Incorrect"));
                    }
                    else
                    {
                        user.Password = model.changePsw.Password;
                        var result = _db.User.Update(user);
                        _db.SaveChanges();
                        if (result != null)
                        {
                            return Ok(Json("true"));
                        }
                        return Ok(Json("false"));
                    }

                }
                return Ok(Json("false"));
            }
            return Ok(Json("false"));

        }

        [HttpPost]
        public IActionResult EditAddress(CombinedAllViewModels model)
        {
            if (ModelState.IsValid)
            {
                UserAddress userAddress = _db.UserAddress.Where(_ => _.AddressId == model.editAdd.AddressId).FirstOrDefault();

                if(userAddress != null)
                {
                    userAddress.AddressLine1 = model.editAdd.AddressLine1;
                    userAddress.AddressLine2 = model.editAdd.AddressLine2;
                    userAddress.PostalCode = model.editAdd.PostalCode;
                    userAddress.City = model.editAdd.City;
                    userAddress.Mobile = model.editAdd.Mobile;

                    var result = _db.UserAddress.Update(userAddress);
                    _db.SaveChanges();

                    if (result != null)
                    {
                        return new JsonResult(model.editAdd);
                    }
                    return Ok(Json("false"));
                }
            }
            return Ok(Json("false"));
        }
    }
}

