using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;

namespace TheRockFanPage.Repos
{
    public class FakeCommentRepo : ICommentRepo
    {
        List<Comment> comments = new List<Comment>();

        public IQueryable<Comment> Comments
        {
            get
            {
                { return comments.AsQueryable<Comment>(); }
            }
        }

        public void AddComment(Comment comment)
        {
            comment.CommentID = comments.Count;
            comments.Add(comment);
        }

        public List<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }



        public Comment GetOneComment_byID(int ID)
        {
            throw new NotImplementedException();
        }


        public void SaveChanges()
        {
            throw new NotImplementedException();
        }


    }
}
