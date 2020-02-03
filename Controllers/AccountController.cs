using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using OnlineStore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> UserMgr, 
            SignInManager<IdentityUser> SignInMgr)
        {
            userManager = UserMgr;
            signInManager = SignInMgr;
        }
        
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { 
            ReturnUrl = returnUrl});
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.Name,
                        loginModel.Password, false, false);
                if (result.Succeeded)
                {
                    
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {

                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Admin", "Index");
                    }
                    

                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl = "/") 
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        public ViewResult Hello()
        {
            return View("Hello everybody");
        }
    }
}
