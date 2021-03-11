using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;
using Microsoft.EntityFrameworkCore;

namespace TheRockFanPage.Repos
{
    public interface ICommentRepo
    {
        IQueryable<Comment> Comments { get; }  // Read (or retrieve) Story

        //IQueryable<StoryModel> Date { get; }       // retrieve message by date

        void AddComment(Comment comment);  // Create a story

        List<Comment> GetAllComments();

        Comment GetOneComment_byID(int ID);

        public void SaveChanges();
     


    }
}
