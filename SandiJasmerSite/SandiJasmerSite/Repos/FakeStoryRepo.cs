using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;

namespace TheRockFanPage.Repos
{
    public class FakeStoryRepo:IStoriesRepo
    {
        List<StoryModel> stories = new List<StoryModel>();

        public IQueryable<StoryModel> Stories
        {
            get
            {
                { return stories.AsQueryable<StoryModel>(); }
            }
        }

        public void AddStory(StoryModel story)
        { 
            story.StoryID = stories.Count;
            stories.Add(story);
        }

        public List<StoryModel> GetAllStories()
        {
           // return stories.Include(e => e.Submitter).Include(e => e.Title).Include(e => e.StoryText).ToList();
            throw new NotImplementedException();
        }

        public StoryModel GetOneStory_byID(int ID)
        {
            // return stories.FirstOrDefault(ID);
            throw new NotImplementedException();
        }

        public StoryModel GetStoryByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateStory(StoryModel story)
        {
            throw new NotImplementedException();
        }
    }
}
