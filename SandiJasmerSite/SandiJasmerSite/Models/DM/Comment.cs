using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRockFanPage.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public String CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public AppUser Commenter { get; set; }

    }
}
