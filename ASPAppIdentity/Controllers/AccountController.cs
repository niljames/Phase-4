using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPAppIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace ASPAppIdentity.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _UserManager;
        private SignInManager<IdentityUser> _SignInManager;

        public AccountController(UserManager<IdentityUser> _UserManager, SignInManager<IdentityUser> _SignInManager)
        {
            this._UserManager = _UserManager;
            this._SignInManager = _SignInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser{UserName = model.Email, Email = model.Email};
            IdentityResult Result = await _UserManager.CreateAsync(user, model.Password);
            if (Result.Succeeded)
            {
                ViewBag.msg = "User registered Successfully.....";
            }
            else
            {
                foreach(var error in Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (model.RememberMe)
                {
                    string key = "ck1";
                    string value = model.Email;
                    CookieOptions cookieOption = new CookieOptions();
                    cookieOption.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Append(key, value, cookieOption);
                }
                HttpContext.Session.SetString("uname", model.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Credentials";
            }
            return View();
        }
        public IActionResult Dashboard()
        {
            var uname = HttpContext.Session.GetString("uname");
            if (uname != null)  //Verify Session exists.
            {
                ViewBag.msg = "Welcome " + uname + " to the dashboard.......State maintained using session.";
                
            }
            else if (Request.Cookies["ck1"] != null)    //Verify Cookie exists.
            {
                //If Session failed and cookie exists.
                uname = Request.Cookies["ck1"].ToString();
                HttpContext.Session.SetString("uname",uname); 
                ViewBag.msg = "Welcome " + uname + " to the dashboard.......State maintained using cookies.";
            }
            else
            {
                ViewBag.msg = "Session Does not exist";
            }
            return View();
        }
        public IActionResult Logout()
        {
            
            var uname = HttpContext.Session.GetString("uname");
            if (uname != null)
            {
                string key = "ck1";
                string value = uname;
                HttpContext.Session.Clear();
                ViewBag.msg = "Welcome to the dashboard";
                
                CookieOptions cookieOption = new CookieOptions();
                cookieOption.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append(key, value, cookieOption);
            }
            else
            {
                ViewBag.msg = "Landed on this page using this technique";
            }
            return View();
        }
        

    }
}
