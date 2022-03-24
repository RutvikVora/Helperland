using Helperland_Clone.Data;
using Helperland_Clone.Enums;
using Helperland_Clone.Models;
using Helperland_Clone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Clone.Controllers
{
    public class AdminController : Controller
    {
        private readonly HelperlandContext _db;

        public AdminController(HelperlandContext db)
        {
            _db = db;
        }
        public IActionResult AdminPanel()
        {
            return View();
        }

        public JsonResult GetServiceRequest(AdminServiceFilterFormViewModel filter)
        {
            //Console.WriteLine(filter.ServiceRequestId);

            List<AdminServiceReqViewModel> tabledata = new List<AdminServiceReqViewModel>();

            var serviceRequestsList = _db.ServiceRequest.ToList();

            foreach (ServiceRequest temp in serviceRequestsList)
            {
                if (checkServiceRequest(temp, filter))
                {


                    AdminServiceReqViewModel req = new AdminServiceReqViewModel();

                    req.ServiceId = temp.ServiceId;
                    req.Date = temp.ServiceStartDate.ToString("dd/MM/yyyy");
                    req.StartTime = temp.ServiceStartDate.AddHours(0).ToString("HH:mm ");
                    var totaltime = (double)(temp.ServiceHours + temp.ExtraHours);
                    req.EndTime = temp.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");
                    req.Status = (int)temp.Status;
                    req.TotalCost = temp.TotalCost;
                    /* customer */

                    User customer = _db.User.FirstOrDefault(x => x.UserId == temp.UserId);

                    req.CustomerName = customer.FirstName + " " + customer.LastName;



                    /*address */

                    ServiceRequestAddress serviceRequestAddress = _db.ServiceRequestAddress.FirstOrDefault(x => x.ServiceRequestId == temp.ServiceRequestId);

                    req.Address = serviceRequestAddress.AddressLine1 + " " + serviceRequestAddress.AddressLine2 + "," + serviceRequestAddress.City + "-" + serviceRequestAddress.PostalCode;

                    req.ZipCode = temp.ZipCode;


                    if (temp.ServiceProviderId != null)
                    {
                        User sp = _db.User.FirstOrDefault(x => x.UserId == temp.ServiceProviderId);

                        req.ServiceProvider = sp.FirstName + " " + sp.LastName;
                        req.UserProfilePicture = sp.UserProfilePicture;


                        decimal rating;

                        if (_db.Rating.Where(x => x.RatingTo == temp.ServiceProviderId).Count() > 0)
                        {
                            rating = _db.Rating.Where(x => x.RatingTo == temp.ServiceProviderId).Average(x => x.Ratings);
                        }
                        else
                        {
                            rating = 0;
                        }
                        req.AverageRating = (float)decimal.Round(rating, 1, MidpointRounding.AwayFromZero);

                    }


                    tabledata.Add(req);
                }




            }

            return Json(tabledata);
        }

        Boolean checkServiceRequest(ServiceRequest req, AdminServiceFilterFormViewModel filter)
        {
            var user = _db.User.FirstOrDefault(x => x.UserId == req.UserId);


            if (filter.ServiceId != null)
            {
                if (req.ServiceId != filter.ServiceId)
                {
                    return false;
                }
            }
            if (filter.ZipCode != null)
            {
                if (req.ZipCode != filter.ZipCode)
                {
                    return false;
                }
            }
            if (filter.Email != null)
            {
                var email = user.Email;
                if (!email.Contains(filter.Email))
                {
                    return false;
                }
            }
            if (filter.CustomerName != null)
            {

                var name = user.FirstName + " " + user.LastName;
                if (!name.Contains(filter.CustomerName))
                {
                    return false;
                }
            }
            if (filter.ServiceProviderName != null)
            {
                User sp = _db.User.FirstOrDefault(x => x.UserId == req.ServiceProviderId);
                if (sp != null)
                {
                    var name = sp.FirstName + " " + sp.LastName;

                    if (!name.Contains(filter.ServiceProviderName))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (filter.Status != null)
            {
                if (req.Status != filter.Status)
                {
                    return false;
                }
            }
            if (filter.FromDate != null)
            {
                DateTime dateTime = Convert.ToDateTime(filter.FromDate);
                if (!(req.ServiceStartDate >= dateTime))
                {
                    return false;
                }

            }
            if (filter.ToDate != null)
            {
                var reqEndDate = req.ServiceStartDate.AddHours((double)(req.ServiceHours + req.ExtraHours));

                DateTime dateTime = Convert.ToDateTime(filter.ToDate);

                if (!(reqEndDate <= dateTime))
                {
                    return false;
                }
            }


            return true;



        }

        public JsonResult GetEditModalDetails(ServiceRequest Id)
        {

            ServiceRequest req = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == Id.ServiceId);

            AdminModalViewModel details = new AdminModalViewModel();

           details.address = _db.ServiceRequestAddress.FirstOrDefault(x => x.ServiceRequestId == req.ServiceRequestId);

            DateTime starttime = req.ServiceStartDate;

            details.Date = starttime.ToString("MM-dd-yyyy");

            details.StartTime = starttime.ToString("HH':'mm':'ss");




            return Json(details);



        }


        public JsonResult UpdateServiceReq(AdminModalViewModel model)
        {
            ServiceRequest serviceRequest = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == model.ServiceId);

            DateTime dateTime = Convert.ToDateTime(model.Date);

            serviceRequest.ServiceStartDate = dateTime;






            ServiceRequestAddress serviceRequestAddress = _db.ServiceRequestAddress.FirstOrDefault(x => x.ServiceRequestId == serviceRequest.ServiceRequestId);



            serviceRequestAddress.AddressLine1 = model.address.AddressLine1;
            serviceRequestAddress.AddressLine2 = model.address.AddressLine2;

            serviceRequestAddress.PostalCode = model.address.PostalCode;
            serviceRequestAddress.City = model.address.City;
            serviceRequestAddress.State = model.address.State;

            var result2 = _db.ServiceRequestAddress.Update(serviceRequestAddress);
            _db.SaveChanges();
            var result1 = _db.ServiceRequest.Update(serviceRequest);
            _db.SaveChanges();

            if (result1 != null && result2 != null)
            {

                //sendMail(serviceRequest);
                return Json("true");
            }
            else
            {
                return Json("false");
            }

        }

        [HttpPost]
        public IActionResult CancelServiceReq(ServiceRequest cancel)
        {




            ServiceRequest cancelService = _db.ServiceRequest.FirstOrDefault(x => x.ServiceId == cancel.ServiceId);
            cancelService.Status = (int?)ServiceRequestStatusEnum.Cancelled;


            var result = _db.ServiceRequest.Update(cancelService);
            _db.SaveChanges();
            if (result != null)
            {

                //await Task.Run(() =>
                //{

                //    if (cancelService.ServiceProviderId != null)
                //    {

                //        User temp = _db.Users.FirstOrDefault(x => x.UserId == cancelService.ServiceProviderId);


                //        MimeMessage message = new MimeMessage();

                //        MailboxAddress from = new MailboxAddress("Helperland",
                //        "darshitkavathiya34@gmail.com");
                //        message.From.Add(from);

                //        MailboxAddress to = new MailboxAddress(temp.FirstName, temp.Email);
                //        message.To.Add(to);

                //        message.Subject = "Service Request cancelled ";

                //        BodyBuilder bodyBuilder = new BodyBuilder();
                //        bodyBuilder.HtmlBody = "<h1>Service request with Id=" + cancelService.ServiceRequestId + ", has been cancled </ h1 > ";



                //        message.Body = bodyBuilder.ToMessageBody();

                //        SmtpClient client = new SmtpClient();
                //        client.Connect("smtp.gmail.com", 587, false);
                //    mailto: client.Authenticate("darshitkavathiya34@gmail.com", "Dar@1234");
                //        client.Send(message);
                //        client.Disconnect(true);
                //        client.Dispose();

                //    }




                //});




                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }




        public JsonResult GetUserData(AdminUserFilterFormViewModel filter)
        {

            var user = _db.User.ToList();

            List<User> result = new List<User>();

            foreach (User temp in user)
            {
                if (checkUserFilter(temp, filter))
                {

                    result.Add(temp);
                }
            }


            return Json(result);





        }

        public bool checkUserFilter(User user, AdminUserFilterFormViewModel filter)
        {

            //Console.WriteLine(filter.ToDate);
            //Console.WriteLine(user.CreatedDate);

            if (filter.Name != null)
            {

                var name = user.FirstName + " " + user.LastName;
                if (!name.Contains(filter.Name))
                {
                    return false;
                }
            }

            if (filter.UserType != null)
            {
                if (user.UserTypeId != filter.UserType)
                {
                    return false;
                }
            }

            if (filter.Phone != null)
            {
                var phone = user.Mobile;
                if (!phone.Contains(filter.Phone))
                {
                    return false;
                }
            }

            if (filter.PostalCode != null)
            {
                if (user.ZipCode != filter.PostalCode)
                {
                    return false;
                }
            }


            if (filter.Email != null)
            {
                var email = user.Email;
                if (!email.Contains(filter.Email))
                {
                    return false;
                }
            }




            if (filter.FromDate != null)
            {
                DateTime dateTime = Convert.ToDateTime(filter.FromDate);
                if (!(user.CreatedDate >= dateTime))
                {
                    return false;
                }

            }

            if (filter.ToDate != null)
            {
                DateTime dateTime = Convert.ToDateTime(filter.ToDate);
                if (!(user.CreatedDate <= dateTime))
                {
                    return false;
                }

            }



            return true;

        }



        public string UserEdit(User Id)
        {
            Console.WriteLine(Id.UserId);
            User user = _db.User.FirstOrDefault(x => x.UserId == Id.UserId);

            var resultString = "Error";

            if (user.IsApproved == false)
            {
                user.IsApproved = true;
                user.IsActive = true;

                resultString = "Service Provider Approved and Activated";
            }
            else if (user.IsActive == false)
            {
                user.IsActive = true;

                resultString = "User Activated";
            }
            else
            {
                user.IsActive = false;

                resultString = "User Deactivated";
            }

            var result = _db.User.Update(user);
            _db.SaveChanges();

            if (result != null)
            {
                return resultString;
            }

            return "Error occured in DataBase, try again";


        }


        




    }
}
