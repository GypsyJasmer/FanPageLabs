using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheRockFanPage.Models;

namespace TheRockFanPage.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userMngr,
            SignInManager<AppUser> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        //This  ties to our ResigterVM HTTP get is optional but by default is always a get. 
        public IActionResult Register()
        {
            return View();
            //no model going because we don't need to pass anything because register page will just be an empty form. 
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
            //async method similar to a promise in JS. This is so it can be executed in the background, instead one at a time. 
            //Multi thread allows for parrell threads to execute lines of code. Threading can only match the cores in CPU. Time slice 
        {
            if (ModelState.IsValid)
            {
                //new local variable user and inititalization list 
                var user = new AppUser { UserName = model.Username };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else //loop through the error list
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        //LOGIN METHODS
        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginVM
            {
                ReturnUrl = returnURL
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        //LOGOUT METHOD 
        //In book it's a post however it is just calling sign in manager and redirects to home once logged out. 
        //Logout is kind of between get & post. 
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
    } 
}
