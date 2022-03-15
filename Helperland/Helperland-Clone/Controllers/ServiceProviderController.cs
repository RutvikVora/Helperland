using Helperland_Clone.Data;
using Helperland_Clone.Enums;
using Helperland_Clone.Models;
using Helperland_Clone.Services;
using Helperland_Clone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helperland_Clone.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly HelperlandContext _db;
        private readonly IUserService _userService;

        public ServiceProviderController(HelperlandContext db, IUserService userService)
        {
            this._db = db;
            _userService = userService;
        }

        public IActionResult SPdashboard()
        {
            ViewBag.IsSpDash = "yes";
            CombinedAllViewModels combine = new CombinedAllViewModels();
            List<SPdashboardViewModel> dashboard = new List<SPdashboardViewModel>();
            List<AddressViewModel> addresses = new List<AddressViewModel>();

            var userId = _userService.GetUserId();
            var userTypeId = _userService.GetUserTypeId();

            int Id = Convert.ToInt32(userId);
            int TypeId = Convert.ToInt32(userTypeId);

            User user = _db.User.FirstOrDefault(x => x.UserId == Id);

            if (TypeId == 2)
            {
                //var table = _db.ServiceRequest.Where(x => x.UserId == Id).ToList();
                List<ServiceRequest> requests = (from request in this._db.ServiceRequest.Where(x => x.ZipCode == user.ZipCode)
                                                 select request).ToList();
                ViewBag.IsComplete = false;
                if (requests.Any())  /*request.Count()>0*/
                {
                    foreach (var service in requests)
                    {

                        SPdashboardViewModel dash = new SPdashboardViewModel();
                        dash.ServiceId = service.ServiceId;
                        var StartDate = service.ServiceStartDate.ToString();
                        dash.Date = service.ServiceStartDate.ToString("dd/MM/yyyy");
                        dash.StartTime = service.ServiceStartDate.AddHours(0).ToString("HH:mm ");
                        var totaltime = (double)(service.ServiceHours + service.ExtraHours);
                        dash.Duration = (decimal)(totaltime);
                        dash.EndTime = service.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");
                        
                        if (service.ServiceStartDate.AddHours(totaltime) < DateTime.Now && (int)service.Status != (int)ServiceRequestStatusEnum.Completed)
                        {
                            dash.Status = (int)ServiceRequestStatusEnum.IsComplete;
                        }
                        else
                        {
                            dash.Status = (int)service.Status;
                        }

                        dash.SpId = service.ServiceProviderId.ToString();
                        dash.TotalCost = service.TotalCost;
                        dash.HasPet = service.HasPets;
                        dash.Comments = service.Comments;

                        User customer = _db.User.FirstOrDefault(x => x.UserId == service.UserId);
                        dash.CustomerName = customer.FirstName + " " + customer.LastName;

                        ServiceRequestAddress Address = (ServiceRequestAddress)_db.ServiceRequestAddress.FirstOrDefault(x => x.ServiceRequestId == service.ServiceRequestId);
                        dash.Address = Address.AddressLine1 + ", " + Address.AddressLine2 + ", " + Address.City + " - " + Address.PostalCode;
                        dash.ZipCode = Address.PostalCode;

                        List<ServiceRequestExtra> SRExtra = _db.ServiceRequestExtra.Where(x => x.ServiceRequestId == service.ServiceRequestId).ToList();

                        foreach (ServiceRequestExtra row in SRExtra)
                        {
                            if (row.ServiceExtraId == 1)
                            {
                                dash.Cabinet = true;
                            }
                            else if (row.ServiceExtraId == 2)
                            {
                                dash.Oven = true;
                            }
                            else if (row.ServiceExtraId == 3)
                            {
                                dash.Window = true;
                            }
                            else if (row.ServiceExtraId == 4)
                            {
                                dash.Fridge = true;
                            }
                            else
                            {
                                dash.Laundry = true;
                            }
                        }

                        dashboard.Add(dash);
                    }
                }

                ViewBag.firstName = user.FirstName;
                ViewBag.lastName = user.LastName;
                ViewBag.email = user.Email;
                ViewBag.mobile = user.Mobile;

                return View(dashboard);
            }

            return RedirectToAction("Index", "Home");
        }

        public string CompletedService(ServiceRequest request)
        {
            ServiceRequest serviceRequest = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == request.ServiceId);

            serviceRequest.Status = (int)ServiceRequestStatusEnum.Completed;
            var result = _db.ServiceRequest.Update(serviceRequest);
            _db.SaveChanges();
            if (result != null)
            {
                return "Success";
            }
            else
            {
                return "error";
            }
        }

        /*--------- Accept Service Req------------*/
        [HttpGet]
        public string acceptService(SPdashboardViewModel ID)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            ServiceRequest serviceRequest = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == ID.ServiceId);
            if (serviceRequest != null && serviceRequest.Status != 1)
            {
                return new string("Service Req Not available");
            }

            int conflict = CheckConflict((int)serviceRequest.ServiceId);

            if (conflict != -1)
            {

                return conflict.ToString();

            }



            serviceRequest.Status = (int)ServiceRequestStatusEnum.Accepted;
            serviceRequest.ServiceProviderId = Id;
            var result = _db.ServiceRequest.Update(serviceRequest);
            _db.SaveChanges();
            if (result != null)
            {
                return "Suceess";
            }
            else
            {
                return "error";
            }

        }


        public string ConflictDetails(SPdashboardViewModel ID)
        {
            Console.WriteLine(ID.ServiceId);

            int conflict = CheckConflict(ID.ServiceId);

            ServiceRequest sr = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == conflict);


            string conflictmsg = "This Request is conflicting with Service ID: " + sr.ServiceId + " on :" + sr.ServiceStartDate;

            return conflictmsg;

        }

        public int CheckConflict(int requestId)
        {

            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);


            ServiceRequest request = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == requestId);

            String reqdate = request.ServiceStartDate.ToString("yyyy-MM-dd");
            Console.WriteLine(reqdate);

            String startDateStr = reqdate + " 00:00:00.000";
            String endDateStr = reqdate + " 23:59:59.999";

            Console.WriteLine(startDateStr);

            DateTime startDate = DateTime.ParseExact(startDateStr, "yyyy-MM-dd HH:mm:ss.fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            DateTime endDate = DateTime.ParseExact(endDateStr, "yyyy-MM-dd HH:mm:ss.fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            List<ServiceRequest> list = _db.ServiceRequest.Where(x => (x.ServiceProviderId == Id) && (x.Status == 4) && (x.ServiceStartDate > startDate && x.ServiceStartDate < endDate)).ToList();

            double mins = ((double)(request.ServiceHours + request.ExtraHours)) * 60;
            DateTime endTimeRequest = request.ServiceStartDate.AddMinutes(mins + 60);

            request.ServiceStartDate = request.ServiceStartDate.AddMinutes(-60);
            Console.WriteLine(endTimeRequest);
            Console.WriteLine(request.ServiceStartDate);
            foreach (ServiceRequest booked in list)
            {
                mins = ((double)(booked.ServiceHours + booked.ExtraHours)) * 60;
                DateTime endTimeBooked = booked.ServiceStartDate.AddMinutes(mins);

                if (request.ServiceStartDate < booked.ServiceStartDate)
                {
                    if (endTimeRequest <= booked.ServiceStartDate)
                    {
                        return -1;
                    }
                    else
                    {
                        return booked.ServiceId;
                    }
                }
                else
                {
                    if (request.ServiceStartDate < endTimeBooked)
                    {
                        return booked.ServiceId;
                    }
                }

            }
            return -1;
        }

        [HttpPost]
        public IActionResult CancelServiceRequest(ServiceRequest cancel)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            Console.WriteLine(cancel.ServiceRequestId);
            ServiceRequest cancelService = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == cancel.ServiceId);
            cancelService.Status = (int)ServiceRequestStatusEnum.Cancelled;
            if (cancel.Comments != null)
            {
                cancelService.Comments = cancel.Comments;
            }
            cancelService.ModifiedBy = Id;
            cancelService.ModifiedDate = DateTime.Now;
            var result = _db.ServiceRequest.Update(cancelService);
            _db.SaveChanges();
            if (result != null)
            {
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }

        //[HttpGet]
        //public IActionResult GetSpDetails()
        //{
        //    var userId = _userService.GetUserId();
        //    int Id = Convert.ToInt32(userId);

        //    User user = _db.User.FirstOrDefault(x => x.UserId == Id);
        //    User sp = new User();
        //    sp.FirstName = user.FirstName;
        //    sp.FirstName = user.FirstName;
        //    sp.Email = user.Email;
        //    sp.Mobile = user.Mobile;
        //    sp.DateOfBirth = user.DateOfBirth;
        //    sp.NationalityId = user.NationalityId;



        //}

        [HttpPost]
        public IActionResult ChangeSpDetails(CombinedAllViewModels model)
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

        public JsonResult GetSpDetail()
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            User sp = _db.User.Where(_ => _.UserId == Id).FirstOrDefault();
            UserAddress spAddress = _db.UserAddress.Where(_ => _.UserId == Id).FirstOrDefault();

            UserViewModel details = new UserViewModel();
            details.FirstName = sp.FirstName;
            details.LastName = sp.LastName;
            details.Email = sp.Email;
            details.Mobile = sp.Mobile;
            details.DateOfBirth = sp.DateOfBirth.ToString();
            if (sp.NationalityId != null)
            {
                details.NationalityId = (int)sp.NationalityId;
            }
            if (sp.Gender != null)
            {
                details.Gender = (int)sp.Gender;
            }

            if (spAddress != null)
            {
                details.AddressLine1 = spAddress.AddressLine1;
                details.AddressLine2 = spAddress.AddressLine2;
                details.City = spAddress.City;
                details.ZipCode = spAddress.PostalCode;
            }

            return Json(new SingleEntity<UserViewModel> { Result = details, Status = "ok", ErrorMessage = null });
        }

        [HttpPost]
        public JsonResult UpdateSpProfileDetail([FromBody] UserViewModel model)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            User sp = _db.User.Where(_ => _.UserId == Id).FirstOrDefault();

            sp.FirstName = model.FirstName.ToString().Trim();
            sp.LastName = model.LastName.ToString().Trim();
            sp.Mobile = model.Mobile.ToString().Trim();
            sp.LanguageId = model.LanguageId;


            if (model.DateOfBirth != null)
            {
                sp.DateOfBirth = Convert.ToDateTime(model.DateOfBirth);
            }

            sp.ModifiedBy = Id;
            sp.ModifiedDate = DateTime.Now;

            UserAddress spAddress = _db.UserAddress.Where(_ => _.UserId == Id).FirstOrDefault();
            if(spAddress != null)
            {
                spAddress.AddressLine1 = model.AddressLine1.ToString().Trim();
                spAddress.AddressLine2 = model.AddressLine2.ToString().Trim();
                spAddress.PostalCode = model.ZipCode.ToString().Trim();
                spAddress.City = model.City.ToString().Trim();

                _db.UserAddress.Update(spAddress);
                _db.SaveChanges();
            }
            else
            {
                UserAddress address = new UserAddress();
                address.AddressLine1 = model.AddressLine1.ToString().Trim();
                address.AddressLine2 = model.AddressLine2.ToString().Trim();
                address.PostalCode = model.ZipCode.ToString().Trim();
                address.City = model.City.ToString().Trim();
                address.UserId = Id;

                _db.UserAddress.Add(address);
                _db.SaveChanges();
            }

            var result = _db.User.Update(sp);
            _db.SaveChanges();

            return Json(new SingleEntity<UserViewModel> { Result = model, Status = "ok", ErrorMessage = null });
        }

        [HttpPost]
        public JsonResult UpdateSpPassword([FromBody] UserViewModel model)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            User sp = _db.User.Where(_ => _.UserId == Id).FirstOrDefault();

            if (model.Password != sp.Password)
            {
                return Json(new SingleEntity<UserViewModel> { Result = model, Status = "Error", ErrorMessage = "Your current password is wrong!" });
            }

            sp.Password = model.NewPassword.ToString().Trim();

            var result = _db.User.Update(sp);
            _db.SaveChanges();

            return Json(new SingleEntity<UserViewModel> { Result = model, Status = "ok", ErrorMessage = null });
        }
    }
}
