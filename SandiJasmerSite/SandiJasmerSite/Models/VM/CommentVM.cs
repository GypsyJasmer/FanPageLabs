using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRockFanPage.Models
{
    public class CommentVM
    {
        public int StoryID { get; set; } 
        public int Subject { get; set; }
        public string CommentText { get; set; }
    }
}
