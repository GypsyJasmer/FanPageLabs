using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;
using Microsoft.EntityFrameworkCore;

namespace TheRockFanPage.Repos
{
    public interface IStoriesRepo
    {
        IQueryable<StoryModel> Stories { get; }  // Read (or retrieve) Story
        void AddStory(StoryModel story);  // Create a story
        StoryModel GetStoryByTitle(string title);  // Retrieve a particular story
    }
}
