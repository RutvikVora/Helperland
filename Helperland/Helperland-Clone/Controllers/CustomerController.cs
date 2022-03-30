using Microsoft.AspNetCore.Mvc;
using Helperland_Clone.Services;
using Helperland_Clone.Data;
using System.Collections.Generic;
using Helperland_Clone.Models;
using Helperland_Clone.ViewModels;
using System;
using System.Linq;
using Helperland_Clone.Enums;
using System.Threading.Tasks;

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
            ViewBag.IsCustomerDash = "yes";
            CombinedAllViewModels combine = new CombinedAllViewModels();
            List<CustomerDashboardViewModel> dashboard = new List<CustomerDashboardViewModel>();
            List<AddressViewModel> addresses = new List<AddressViewModel>();

            var userId = _userService.GetUserId();
            var userTypeId = _userService.GetUserTypeId();

            int Id = Convert.ToInt32(userId);
            int TypeId = Convert.ToInt32(userTypeId);

            //string userName = _userService.GetUserName();
            //ViewData["UserName"] = userName;


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

                            if (_db.Rating.Where(x => x.ServiceRequestId == service.ServiceRequestId).Count() > 0)
                            {
                                Rating rating = _db.Rating.Where(x => x.ServiceRequestId == service.ServiceRequestId).FirstOrDefault();

                                dash.SPRatings = rating.Ratings;
                                dash.OnTimeArrival = rating.OnTimeArrival;
                                dash.Friendly = rating.Friendly;
                                dash.QualityOfService = rating.QualityOfService;
                            }

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

            //int newServiceId = 999;
            //try
            //{
            //    newServiceId = _db.ServiceRequest.Max(x => x.ServiceId);
            //}
            //catch (Exception)
            //{
            //    newServiceId = 999;
            //}

            //newServiceId++;
            //rescheduleService.ServiceId = newServiceId;

            var result = _db.ServiceRequest.Update(rescheduleService);
            _db.SaveChanges();

            CustomerDashboardViewModel updatedDetails = new CustomerDashboardViewModel();
            updatedDetails.Date = rescheduleService.ServiceStartDate.ToString("dd/MM/yyyy");
            updatedDetails.StartTime = rescheduleService.ServiceStartDate.ToString("HH:mm ");
            var totaltime = (double)(rescheduleService.ServiceHours + rescheduleService.ExtraHours);
            updatedDetails.EndTime = rescheduleService.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");


            if (result != null)
            {
                if (rescheduleService.ServiceProviderId != null)
                {
                    sendMail(rescheduleService, "reschedule");
                }
                //return Ok(Json("true"));
                return new JsonResult(updatedDetails);
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
                if (cancelService.ServiceProviderId != null)
                {
                    sendMail(cancelService, "cancel");
                }
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
                    if (!BCrypt.Net.BCrypt.Verify(model.changePsw.Password, user.Password))
                    {
                        return Ok(Json("Incorrect"));
                    }
                    else
                    {
                        user.Password = BCrypt.Net.BCrypt.HashPassword(model.changePsw.Password);
                        //user.Password = model.changePsw.Password;
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


        public IActionResult RateServiceProvider(Rating rating)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

                if (_db.Rating.Where(x => x.ServiceRequestId == rating.ServiceRequestId).Count() > 0)
                {
                    return Ok(Json("false"));
                }


                rating.RatingDate = DateTime.Now;
                ServiceRequest sr = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == rating.ServiceRequestId);
                rating.ServiceRequestId = sr.ServiceRequestId;
                rating.RatingTo = (int)sr.ServiceProviderId;
                rating.RatingFrom = (int)Id;
                Console.WriteLine(rating.Ratings);

                var result = _db.Rating.Add(rating);
                _db.SaveChanges();

                if (result != null)
                {
                    return Ok(Json("true"));
                }

            return Ok(Json("false"));
        }


        public JsonResult getSP()
        {

            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            List<int?> SPID = _db.ServiceRequest.Where(x => x.UserId == Id && x.Status == (int)ServiceRequestStatusEnum.Completed).Select(u => u.ServiceProviderId).ToList();


            var SPSetId = new HashSet<int?>(SPID);

            List<FavoriteAndBlockedViewModel> blockData = new List<FavoriteAndBlockedViewModel>();

            foreach (int temp in SPSetId)
            {
                User user = _db.User.FirstOrDefault(x => x.UserId == temp);
                FavoriteAndBlocked FB = _db.FavoriteAndBlocked.FirstOrDefault(x => x.UserId == Id && x.TargetUserId == temp);

                FavoriteAndBlockedViewModel blockCustomerData = new FavoriteAndBlockedViewModel();
                blockCustomerData.user = user;
                blockCustomerData.favoriteAndBlocked = FB;

                blockData.Add(blockCustomerData);



            }



            return Json(blockData);


        }


        public string BlockUnblockFavUnFavSp(FavoriteAndBlockedViewModel temp)
        {
            var userId = _userService.GetUserId();
            int Id = Convert.ToInt32(userId);

            FavoriteAndBlocked obj = _db.FavoriteAndBlocked.FirstOrDefault(x => x.UserId == Id && x.TargetUserId == temp.Id);

            if (temp.Req == "B")
            {

                if (obj == null)
                {
                    obj = new FavoriteAndBlocked();
                    obj.UserId = (int)Id;
                    obj.TargetUserId = temp.Id;
                    obj.IsBlocked = true;

                }
                else
                {
                    obj.IsBlocked = true;
                }

            }
            else if (temp.Req == "U")
            {
                obj.IsBlocked = false;

            }



            if (temp.Req == "F")
            {

                if (obj == null)
                {
                    obj = new FavoriteAndBlocked();
                    obj.UserId = (int)Id;
                    obj.TargetUserId = temp.Id;
                    obj.IsFavorite = true;

                }
                else
                {
                    obj.IsFavorite = true;
                }

            }
            else if (temp.Req == "N")
            {
                obj.IsFavorite = false;

            }




            var result = _db.FavoriteAndBlocked.Update(obj);
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

        public async Task sendMail(ServiceRequest req, string purpose)
        {
            User user = _db.User.Where(x => x.UserId == req.ServiceProviderId).FirstOrDefault();

            await Task.Run(() =>
            {
              
                    if (purpose == "reschedule")
                    {
                        var email = new ResetPswViewModel()
                        {
                            To = user.Email,
                            Subject = "Rescheduled Service",
                            IsHTML = true,
                            Body = $"<h1>A service with ID number " + req.ServiceRequestId + " has been updated by customer</h1><br>" + "<h2>With time : " + req.ServiceStartDate + "</h2>",
                        };
                        EmailService.SendMail(email);
                    }
                    else if (purpose == "cancel")
                    {
                        var email = new ResetPswViewModel()
                        {
                            To = user.Email,
                            Subject = "Service Canceled",
                            IsHTML = true,
                            Body = $"<h1>Service request with Id=" + req.ServiceRequestId + ", has been canceled by customer</ h1 > ",
                        };
                        EmailService.SendMail(email);
                    }
            });

        }


    }
}

