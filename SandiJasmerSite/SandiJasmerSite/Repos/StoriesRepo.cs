using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;
using Microsoft.EntityFrameworkCore;

namespace TheRockFanPage.Repos
{
    // this class inherits from the Interface
    // auto implemet methods from Interface class (polymorphism)
    // Dependency injection happens in Startup.cs file. 
    public class StoriesRepo:IStoriesRepo
    {
        // Repository needs to use a database context object (it is how we interact with the database)
        // MessageContext constructor takes a parameter

        private StoriesContext context;     // need a field for the database context  

        // constructor where we pass in the actual context object
        // Pass the context into the constructor, and in our controler along with the Repository

        public StoriesRepo(StoriesContext c)
        {
            context = c;
        }

        public IQueryable<StoryModel> Stories
        {
            get
            {
                // use Include, because Messenger object in Message.cs is a User
                // when we pull something from the DBContext, it will not go past the 'top level' object (which is Message)
                // this will return the messages
                return context.Stories.Include(story => story.Submitter);
            }
        }

        public void AddStory(StoryModel stories)
        {
            //store the model in the database. These are coming from StoriesContext
            context.Stories.Add(stories);
            context.SaveChanges(); //always save, and that will put data into the database
        }

        public StoryModel GetStoryByTitle(string title)
        {
            throw new NotImplementedException();
        }

    }



}
