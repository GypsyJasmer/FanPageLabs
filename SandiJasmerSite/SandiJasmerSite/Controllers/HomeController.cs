using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;

namespace TheRockFanPage.Controllers
{
    public class HomeController : Controller
    {
        //field
        //StoriesContext context;
        IStoriesRepo repo;
        UserManager<AppUser> userManager;

        public HomeController(IStoriesRepo r, UserManager<AppUser> u)
        {
            //object being passed in and assigning it. 
            repo = r;
            //Getting the object from DI
            userManager = u;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Authorize]
        [HttpGet]// Invoke the view with form for entering a review
        public IActionResult Stories()
        {/*
            StoriesModels model = new StoriesModels();
            user submitter = new user();
            model.Submitter = submitter;
            */
            return View();
        }

        [HttpPost]
        public IActionResult Stories(StoryModel model)
        {
            if (ModelState.IsValid)
            {
                model.Submitter = userManager.GetUserAsync(User).Result; //returns an identity user object. 
                                                                         //Submitter is an appuser object is a identity user object. 

                // TODO: get the user's real name in registration
                model.Submitter.Name = model.Submitter.UserName;  // temporary hack shows username when they submitt a story. 
                model.DateSubmitted = DateTime.Now;

                // Store the model in the database
                repo.AddStory(model);

            }
               
            return View(model);           
        }

        
        [HttpPost]
        public IActionResult AllStories(string storyTitle, string SubmitterName)
        {
            List<StoryModel> stories = null;

            if (storyTitle != null)
            {
                stories = (from r in repo.Stories
                           where r.Title == storyTitle
                           select r).ToList();
            }

            else if (SubmitterName != null)
            {
                stories = (from r in repo.Stories
                           where r.Submitter.Name == SubmitterName
                           select r).ToList();
            }

            return View(stories);
        }
        

        //this method will send data to the webpage
        public IActionResult AllStories()
        {
            //pulling a list of all stories out of the DB
            //Putting them into a list of stories 
            //Mesenger comes from Message model, it is the User FK
            //var allStories = context.Stories.Include(allStories=>allStories.Submitter).ToList<StoryModel>();
            List<StoryModel> allStories = repo.Stories.ToList<StoryModel>();//Submitter comes from StoryModel model, it is the User FK
            //sent to a new view (to be created)
            return View(allStories);
            
        }

    }
}

