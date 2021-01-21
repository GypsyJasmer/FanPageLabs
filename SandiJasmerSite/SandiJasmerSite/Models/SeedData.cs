using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TheRockFanPage.Models
{
    public class SeedData
    {
        public static void Seed(StoriesContext context)

        {

            if (!context.Stories.Any())  // this is to prevent adding duplicate data

            {
                StoryModel story = new StoryModel

                {
                    Title = "Raw is War",

                    StoryText = "Is The Rock a Smackdown superstart or a Raw superstar?",

                    Submitter = new AppUser { Name = "Emma Watson" },

                    DateSubmitted = DateTime.Parse("11/1/2020")
                };

                context.Stories.Add(story);  // queues up a review to be added to the DB

                story = new StoryModel
                 {
                    Title = "Smackdown",

                    StoryText = "Is The Rock a Smackdown superstart or a Raw superstar?",

                    Submitter = new AppUser { Name = "Dwayne Johnson" },

                    DateSubmitted = DateTime.Parse("11/1/2020")
                 };

                context.Stories.Add(story);

                // My next two reviews will be by the same user, so I will create
                // the user object once and store it so that both reviews will be
                // associated with the same entity in the DB.
                AppUser submitterSandiJasmer = new AppUser() { Name = "Sandi Jasmer" };
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

                story = new StoryModel
                {
                    Title = "Favorite Rock Match",

                    StoryText = "I went to Wrestlemania 17 and The Rock was matched against Hulk Hogan. It was awesome! The Rock won!",

                    Submitter = submitterSandiJasmer,

                    DateSubmitted = DateTime.Parse("11/1/2020")
                };

                //context.Stories.Add(story);​

                context.SaveChanges(); // stores all the reviews in the DB

            }

        }

    }
}

