using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRockFanPage.Models
{
    public class CommentVM
    {
        public int MessageID { get; set; } // Identifies the message being reviewed
        public int Subject { get; set; }
        public string CommentText { get; set; }
    }
}
