using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRockFanPage.Repos;

namespace TheRockFanPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesAPIController : ControllerBase
    {
        private readonly IStoriesRepo repo;

        public StoriesAPIController(IStoriesRepo r)
        {
            repo = r;
        }

        //GET ALL
        public IActionResult GetAllStories()
        {
            var v_stories = repo.GetAllStories();
            if (v_stories.Count == 0)
            {
                return NotFound();
            }
            else
            {
                //ok is a method similar to not found
               return Ok(v_stories); 
            }

        }

        //GET ONE
        [HttpGet("{id}")]
        public IActionResult GetOneStory(int id)
        {
            var v_stories = repo.GetOneStory_byID(id);
            if (v_stories == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(v_stories);
            }

        }




    }
}
