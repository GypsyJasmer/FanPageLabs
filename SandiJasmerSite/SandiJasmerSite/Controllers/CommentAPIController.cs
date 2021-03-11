using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;

namespace TheRockFanPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentAPIController : ControllerBase
    {
        private readonly ICommentRepo repo;

        public CommentAPIController(ICommentRepo r)
        {
            repo = r;
        }

        //GET ALL
        public IActionResult GetAllComments()
        {
            var v_comments = repo.GetAllComments();
            if (v_comments.Count == 0)
            {
                return NotFound();
            }
            else
            {
                //ok is a method similar to not found
                return Ok(v_comments);
            }

        }

        //GET ONE
        [HttpGet("{id}")]
        public IActionResult GetOneComment(int id)
        {
            var v_comments = repo.GetOneComment_byID(id);
            if (v_comments == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(v_comments);
            }

        }

        [HttpPost]
        public IActionResult PostCommenty(Comment postComment)
        {
            repo.AddComment(postComment);
            repo.SaveChanges();

            return CreatedAtAction("GetOneStory", new { id = postComment.CommentID }, postComment);
        }



    }
}
