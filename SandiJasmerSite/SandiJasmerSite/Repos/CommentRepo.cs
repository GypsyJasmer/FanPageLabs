using System;
using System.Linq;
using TheRockFanPage.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TheRockFanPage.Repos
{
 
    public class CommentRepo : ICommentRepo
    {
       
        private StoriesContext context;     

        public CommentRepo(StoriesContext c)
        {
            context = c;
        }

        public IQueryable<Comment> Comments
        {
            get
            {
                return context.Comments.Include(comment => comment.Commenter);
                  
            }
        }

        /*************Add & Update Comment******/
        public void AddComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges(); //always save, and that will put data into the database
        }

        /*************Get all API******/
        public List<Comment> GetAllComments()
        {
            return context.Comments.ToList();
        }



        /*************Get one Comment by ID for API******/
 
        public Comment GetOneComment_byID(int ID)
        {
            return context.Comments.Find(ID);
        }


        public void SaveChanges()
        {
            context.SaveChanges();
        }


    }


}
