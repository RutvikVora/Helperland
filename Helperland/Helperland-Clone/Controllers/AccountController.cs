using Helperland_Clone.Data;
using Helperland_Clone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Helperland.Enums;
using Helperland_Clone.ViewModels;
using Helperland.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helperland_Clone.Controllers
{
    public class AccountController : Controller
    {
        private readonly HelperlandContext _helperlandContext;

        public AccountController(HelperlandContext helperlandContext)
        {
            this._helperlandContext = helperlandContext;
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
                     new Claim(ClaimTypes.Name, user.Email),
                     new Claim("FirstName",user.FirstName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties() { IsPersistent = viewModel.IsPersistant };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("InvalidCredentials", "Either username or password is not correct");
                }
            }
            TempData["msg"] = "<script>alert('Either username or password is not correct')</script>";
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (login != null)
            {
                TempData["msg"] = "<script>alert('successfully logout')</script>";
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationViewModel userModel)
        {
            if (ModelState.IsValid)
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
            return View(userModel);
        }

        public IActionResult ServiceProviderRegistration(UserRegistrationViewModel model)
        {
            if (ModelState.IsValid)
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

                TempData["SuccessMessage"] = "Register Successfully. You can login after admin can approved your request.";

                return RedirectToAction();
            }

            return View("BecomeSP");
        }

        public IActionResult BecomeSP()
        {
            return View();
        }
    }
}
