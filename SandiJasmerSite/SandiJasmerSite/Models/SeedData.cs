using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TheRockFanPage.Models
{
    public class SeedData
    {
        public static void Seed(StoriesContext context, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Stories.Any())  // this is to prevent adding duplicate data
            {
                //create member role
                var result = roleManager.CreateAsync(new IdentityRole("Member")).Result;
                result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;

                /***********************Seeding a default administrator. They will need to change their password after logging in.*****************/
                /*AppUser siteadmin = new AppUser
                {
                    UserName = "SiteAdmin",
                    Name = "Site Admin"
                };
                userManager.CreateAsync(siteadmin, "Secret-123").Wait();
                IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
                userManager.AddToRoleAsync(siteadmin, adminRole.Name); */

                /******************User1****************/
                AppUser emmaWatson = new AppUser 
                {
                    UserName = "EWatson",
                    Name = "Emma Watson" 
                };
                context.Users.Add(emmaWatson);
                context.SaveChanges(); // stores all the reviews in the DB

                StoryModel story = new StoryModel

                {
                    Title = "Raw is War",
                    StoryText = "Is The Rock a Smackdown superstart or a Raw superstar?",
                    Submitter = emmaWatson,
                    DateSubmitted = DateTime.Parse("11/1/2020")
                };

                context.Stories.Add(story);  // queues up a review to be added to the DB

                /******************User2****************/
                AppUser dwayneJohnson = new AppUser 
                {
                    UserName = "TheRock",
                    Name = "Dwayne Johnson" 
                };
                context.Users.Add(dwayneJohnson);
                context.SaveChanges(); // stores all the reviews in the DB

                story = new StoryModel
                {
                    Title = "Smackdown",
                    StoryText = "Is The Rock a Smackdown superstart or a Raw superstar?",
                    Submitter = dwayneJohnson,
                    DateSubmitted = DateTime.Parse("11/1/2020")
                 };

                context.Stories.Add(story);

                /******************User3****************/

                AppUser submitterSandiJasmer = new AppUser
                {
                    UserName = "Sandos",
                    Name = "Sandi Jasmer" 
                };
                context.Users.Add(submitterSandiJasmer);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                story = new StoryModel
                {
                    Title = "If I was a WWE Superstar",
                    StoryText = "My persona would be called Sugar N' Spice and I'd be really sweet but then hardcore at getting the title.",
                    Submitter = submitterSandiJasmer,
                    DateSubmitted = DateTime.Parse("11/1/2020")
                };
                context.Stories.Add(story);


                context.SaveChanges(); // stores all the reviews in the DB

            }

        }

    }
}

