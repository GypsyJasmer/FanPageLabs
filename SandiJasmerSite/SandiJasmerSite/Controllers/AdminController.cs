using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;

namespace TheRockFanPage.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //field
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IStoriesRepo storiesRepo;


        //constructor passing in 3 varaibles and user and role manager are apart of Identity Dependance Injection out of startup. 
        public AdminController(UserManager<AppUser> userMngr,
                               RoleManager<IdentityRole> roleMngr,
                               IStoriesRepo repo)
        {
            userManager = userMngr;
            roleManager = roleMngr;
            storiesRepo = repo;
        }
       
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = new List<AppUser>();
            foreach (AppUser user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                //appuser objects into list of users. We're doing it using the user manager
                users.Add(user);
            }

            AdminVM model = new AdminVM
            {
                Users = users, // List of AppUsers
                Roles = roleManager.Roles
            };

            return View(model);
        } 
        
        // the other action methods } 
/****************DELETE**********************/
       [HttpPost]
       public async Task<IActionResult> Delete(string id)
       {
           IdentityResult result = null;
           AppUser user = await userManager.FindByIdAsync(id);
           if (user != null)
           {
               // Check to see if the user has posted any stories in the db
               if (0 == (from r in storiesRepo.Stories
                         where r.Submitter.Name == user.Name
                         select r).Count<StoryModel>())
               {
                   //delete if stories posted
                   result = await userManager.DeleteAsync(user);
               }
               else // Error promted if user has stories in DB
               {               
                   result = IdentityResult.Failed(new IdentityError()
                   { Description = "User's reviews must be deleted first" });
               }

                // if failed to delete user 
                if (!result.Succeeded) 
                {                  
                   string errorMessage = "";
                   foreach (IdentityError error in result.Errors)
                   {
                       errorMessage += errorMessage != "" ? " | " : "";   // put a separator between messages
                       errorMessage += error.Description;
                   }
                   //TempData is like ViewBag or ViewData it holds the error message
                   TempData["message"] = errorMessage;
               }
               else //if succeeds we will clear error message of user having reviews. 
               {
                   TempData["message"] = "";  
               }
           }
           return RedirectToAction("Index");
       }

      /*************ADD TO ADMIN*************/
       [HttpPost]
       public async Task<IActionResult> AddToAdmin(string id)
       {
           IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            //if admin 
           if (adminRole == null)
           {
               TempData["message"] = "Admin role does not exist. "
                   + "Click 'Create Admin Role' button to create it.";
           }
           else //create that user to be admin
           {
               AppUser user = await userManager.FindByIdAsync(id);
               await userManager.AddToRoleAsync(user, adminRole.Name);
           }
           return RedirectToAction("Index");
       }

        /*************REMOVE FROM ADMIN*************/
        [HttpPost]
       public async Task<IActionResult> RemoveFromAdmin(string id)
       {
           AppUser user = await userManager.FindByIdAsync(id);
           var result = await userManager.RemoveFromRoleAsync(user, "Admin");
           if (result.Succeeded) { }
           return RedirectToAction("Index");
       }
       

        /****************  Role management *******************/
        /*
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterVM model)
        {

            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Username };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        */
    }
}

