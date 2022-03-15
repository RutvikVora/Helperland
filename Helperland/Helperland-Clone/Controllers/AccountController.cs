using Helperland_Clone.Data;
using Helperland_Clone.Models;
using Helperland_Clone.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Helperland.Enums;
using Helperland_Clone.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Helperland_Clone.Controllers
{
    public class AccountController : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        private readonly EmailService sendEmail;
        public readonly IDataProtector protector;
        public readonly string Key = "Rutvik@2000@Vora";

        public AccountController(HelperlandContext helperlandContext, IDataProtectionProvider protector, EmailService sendEmail)
        {
            this._helperlandContext = helperlandContext;
            this.sendEmail = sendEmail;
            this.protector = protector.CreateProtector(Key);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // note : real time we save password with encryption into the database
                // so to check that viewModel.Password also need to encrypt with same algorithm 
                // and then that encrypted password value need compare with database password value
                Models.User user = _helperlandContext.User.Where(_ => _.Email.ToLower() == viewModel.Email.ToLower() && _.Password == viewModel.Password).FirstOrDefault();
                if (user != null)
                {
                        _helperlandContext.SaveChanges();
                        var claims = new List<Claim>
                        {
                             new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                             new Claim(ClaimTypes.Email, user.Email),
                             new Claim(ClaimTypes.Name, Convert.ToString(user.FirstName)),
                             new Claim(ClaimTypes.GivenName, Convert.ToString(user.UserTypeId))
                        };
                       
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties() {
                            IsPersistent = viewModel.IsPersistant,
                            ExpiresUtc = DateTime.UtcNow.AddMonths(1)
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                    if (user.UserTypeId == 3)
                    {
                        return RedirectToAction("CustomerDashboard", "Customer");
                    }
                    else if (user.UserTypeId == 2)
                    {
                        return RedirectToAction("SPdashboard", "ServiceProvider");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //ModelState.AddModelError("InvalidCredentials", "Either username or password is not correct");
                    TempData["InvalidCreds"] = "Invalid Credentials";
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["InvalidCreds"] = "Invalid Credentials";
            //TempData["msg"] = "<script>alert('Either username or password is not correct')</script>";
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (login != null)
            {
                //TempData["msg"] = "<script>alert('successfully logout')</script>";
                TempData["SuccessPopUpStatus"] = "Logout";
            }
            return RedirectToAction("Index", "Home");
        }


        public bool isEmailExit(String email)
        {
            var IsCheck = _helperlandContext.User.Where(_ => _.Email == email).FirstOrDefault();
            return IsCheck != null;

        }

        [HttpPost]
        public IActionResult Register(UserRegistrationViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                if (isEmailExit(userModel.Email))
                {
                    TempData["ErrorMessage"] = "Email already exists,please choose another email!!";
                }
                else
                {
                    User user = new User
                    {
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        Email = userModel.Email,
                        Password = userModel.Password,
                        Mobile = userModel.Mobile,
                        UserTypeId = (int)UserTypeEnum.Customer,
                        CreatedDate = DateTime.Now,
                        IsApproved = true,
                        ModifiedDate = DateTime.Now
                    };

                    _helperlandContext.User.Add(user);
                    _helperlandContext.SaveChanges();

                    TempData["SuccessMessage"] = "Register Successfully.";

                    return RedirectToAction();
                }
            }
            return View("Register");
        }

        public IActionResult ServiceProviderRegistration(UserRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (isEmailExit(model.Email))
                {
                    TempData["ErrorMessage"] = "<script>alert('Email already exists!!')</script>";
                }
                else
                {
                    User user1 = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password,
                        Mobile = model.Mobile,
                        UserTypeId = (int)UserTypeEnum.ServiceProvider,
                        CreatedDate = DateTime.Now,
                        IsApproved = false,
                        ModifiedDate = DateTime.Now
                    };

                    _helperlandContext.User.Add(user1);
                    _helperlandContext.SaveChanges();

                    //TempData["SuccessMessage"] = "Register Successfully. You can login after admin can approved your request.";
                    //TempData["PopUpStatus"] = "Registered";
                    return RedirectToAction("BecomeSP", "Account");
                }
            }

            return View("BecomeSP");
        }

        public IActionResult BecomeSP()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            try
            {
                var decryptId = protector.Unprotect(token);
                DateTime expiryDate = DateTime.Parse(decryptId.Split("%")[2]).AddHours(1);
                DateTime current = DateTime.UtcNow;
                int isvalid = current.CompareTo(expiryDate);

                if (isvalid > 0)
                {
                    throw new Exception();
                }
                return View("~/Views/Account/ResetPassword.cshtml");

            }
            catch
            {
                return BadRequest(error: "Invalid Link");
            }
        }

        [HttpPost]
        public IActionResult ResetPassword(UserRegistrationViewModel model, string token)
        {
            string decryptId = protector.Unprotect(token);
            if (decryptId != null)
            {
                int userId = Convert.ToInt32(decryptId.Split("%")[1]);
                var user = _helperlandContext.User.Where(e => e.UserId == userId).FirstOrDefault();
                //user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                user.Password = model.Password;
                _helperlandContext.User.Attach(user);
                _helperlandContext.SaveChanges();
                TempData["SuccessPopUpStatus"] = "ChangePassword";
                return RedirectToAction("index", "Home");
            }
            return BadRequest(error: "Invalid Link");
        }

        [HttpPost]
        public IActionResult ResetLink(UserLoginViewModel model)
        {
            var user = _helperlandContext.User.Where(x => x.Email.Equals(model.Email)).FirstOrDefault();

            if (user != null)
            {
                
                string Tokenstr = model.Email + "%" + user.UserId + "%" + DateTime.UtcNow;
                string Token = protector.Protect(Tokenstr);

                string ResetURL = Url.Action("ResetPassword", "Account", new { token = Token }, Request.Scheme);
                var email = new ResetPswViewModel()
                {
                    To = model.Email,
                    Subject = "Reset password of your account in helperland",
                    IsHTML = true,
                    Body = $"To reset your password of Helperland.<p><a href='{ResetURL}'>Click Here</a></p>",
                };
                bool result = EmailService.SendMail(email);
                if (result)
                {
                    TempData["SuccessPopUpStatus"] = "PasswordResetLinkSent";
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    TempData["Error"] = "Internal Server Error";
                    return RedirectToAction("index", "Home");
                }
            }
            TempData["Error"] = "Email is not registered";
            return RedirectToAction("index", "Home");
            //return BadRequest(error: "Email is not registered");
        }

    }
}
