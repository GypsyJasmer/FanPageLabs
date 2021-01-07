using System;
using Xunit;
using System.Linq;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;
using TheRockFanPage.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace Tests
{
    public class StoriesTest
    {
        [Fact]
        public void AddStory()
        {
            // Arrange
            var fakeRepo = new FakeStoryRepo();
            var controller = new HomeController(fakeRepo);
            var story = new StoryModel()
            {
                Title = "SmackDown vs. Raw is War",
                Submitter = new User() { Name = "Sugar n Spice" },
                StoryText = "SmackDown was alwaysbetter"
            };

            //Act
            controller.Stories(story);

            //Assert
            // ensure that the review was added to the repository
            var retrievedStory = fakeRepo.Stories.ToList()[0];
            Assert.Equal(System.DateTime.Now.Date.CompareTo(retrievedStory.DateSubmitted.Date), 0);
        }

        // a unit test that passes an instance of the fake repository to the controller
        [Fact]
        public void IndexActionMethod_ReturnsAViewAsAResult()
        {
            // arrange
            var fakeRepo = new FakeStoryRepo();
            var controller = new HomeController(fakeRepo);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
