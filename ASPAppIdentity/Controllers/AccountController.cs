using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPAppIdentity.Models;
using Microsoft.AspNetCore.Identity;

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
            var result = await _SignInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe,false);
            if (result.Succeeded)
            {
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
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        

    }
}
